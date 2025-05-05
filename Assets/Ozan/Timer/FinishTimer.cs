using UnityEngine;
using TMPro;

public class FinishTimer : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;

    void Start()
    {
        float elapsedTime = GameTimer.finalTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        finalTimeText.text = "Survival Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}