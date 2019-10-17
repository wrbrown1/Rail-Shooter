using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class with handle how all forms of player collision behave
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX; 

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()//Called by string reference
    {
        deathFX.SetActive(true);
        SendMessage("PlayerDeath");
        Invoke("LoadScene", levelLoadDelay);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
