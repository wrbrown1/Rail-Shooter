using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        Invoke("LoadFirstScene", 5f); //Invoke calls a method (passed as a string) after a specified time
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
