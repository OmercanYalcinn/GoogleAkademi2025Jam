using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Controls-Credits-Scene"); 
    }
}