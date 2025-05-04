using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    public Sprite unmuteIcon;
    public Sprite muteIcon;
    public Image buttonImage;

    private AudioSource musicSource;
    private bool isMuted = false;

    void Start()
    {
        // Sahnedeki müzik yöneticisini bul ve ses kaynağını al
        GameObject musicObj = GameObject.FindGameObjectWithTag("Music");
        if (musicObj != null)
        {
            musicSource = musicObj.GetComponent<AudioSource>();
        }
    }

    public void ToggleSound()
    {
        if (musicSource == null) return;

        isMuted = !isMuted;
        musicSource.mute = isMuted;
        buttonImage.sprite = isMuted ? muteIcon : unmuteIcon;
    }
}
