﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 5f); //Invoke calls a method (passed as a string) after a specified time
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
