using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seftdestruct : MonoBehaviour
{
    //simple script to destroy a game object after a 5 second delay
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}
