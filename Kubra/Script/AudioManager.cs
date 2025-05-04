using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource audioSource;
    public GameObject muteButton;
    public GameObject unmuteButton;
    private bool isMuted = false;
    private float savedTime = 0f;  // Şarkının kaydedilen zamanı

    void Awake()
    {
        // Eğer başka bir AudioManager varsa, onu yok et
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);  // Bu objeyi sahneler arasında taşır
    }

    void Start()
    {
        // PlayerPrefs'ten mute durumu alınıyor
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        audioSource.mute = isMuted;

        // Müzik çalmıyorsa ve mute değilse, müzik başlatılıyor
        if (!audioSource.isPlaying && !isMuted)
        {
            audioSource.loop = false;  // Şarkının başa sarıp saramayacağını kontrol et
            audioSource.time = savedTime;  // Eğer daha önce bir zaman kaydedildiyse, bu zamandan devam et
            audioSource.Play();
        }

        AssignButtons();  // Butonları ayarla
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahne değiştikten sonra mute/unmute durumunu kontrol et
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        audioSource.mute = isMuted;
        audioSource.time = savedTime;  // Sahne değiştiğinde ses kaldığı yerden başlar
        UpdateButtonVisibility();
    }

    void AssignButtons()
    {
        // Mute ve Unmute butonlarını sahnede bul
        muteButton = GameObject.Find("Mute");
        unmuteButton = GameObject.Find("Unmute");

        // Mute butonunu tıklandığında ses açma/kapama işlevini ekle
        if (muteButton != null)
        {
            muteButton.GetComponent<Button>().onClick.RemoveAllListeners();
            muteButton.GetComponent<Button>().onClick.AddListener(ToggleSound);
        }

        // Unmute butonunu tıklandığında ses açma/kapama işlevini ekle
        if (unmuteButton != null)
        {
            unmuteButton.GetComponent<Button>().onClick.RemoveAllListeners();
            unmuteButton.GetComponent<Button>().onClick.AddListener(ToggleSound);
        }

        // Buton görünürlüğünü güncelle
        UpdateButtonVisibility();
    }

    public void ToggleSound()
    {
        // Ses açma/kapama işlemi
        isMuted = !isMuted;
        audioSource.mute = isMuted;

        // PlayerPrefs'te mute durumu kaydedilir
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();  // PlayerPrefs'i kaydet

        // Butonları güncelle
        UpdateButtonVisibility();
    }

    void UpdateButtonVisibility()
    {
        // Ses açıksa unmute, kapalıysa mute butonunu göster
        if (muteButton != null)
            muteButton.SetActive(!isMuted);

        if (unmuteButton != null)
            unmuteButton.SetActive(isMuted);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)  // Uygulama duraklatıldığında
        {
            savedTime = audioSource.time;  // Şarkının anlık zamanını kaydet
        }
    }

    void OnApplicationQuit()
    {
        // Uygulama kapanırken de şarkının zamanını kaydedelim
        savedTime = audioSource.time;
    }
}
