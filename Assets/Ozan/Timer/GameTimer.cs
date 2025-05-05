using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static float finalTime = 0f;

    private float elapsedTime = 0f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Sürekli güncelle (veya sadece sahne geçişi öncesi de olur)
        finalTime = elapsedTime;
    }
}