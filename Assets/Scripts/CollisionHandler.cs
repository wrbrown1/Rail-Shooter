using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class with handle how all forms of player collision behave
public class CollisionHandler : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()//Called by string reference
    {
        SendMessage("PlayerDeath");

    }
}
