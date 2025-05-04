using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public AudioSource musicSource; // Bu alanı mute scripti kullanacak

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.tag = "Music"; // Mute scriptinin bulabilmesi için
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
