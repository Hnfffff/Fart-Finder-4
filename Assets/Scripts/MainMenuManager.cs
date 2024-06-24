using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource mainMenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuMusic.loop = true;
        mainMenuMusic.Play();
    }
}
