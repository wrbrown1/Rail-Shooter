using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    int score;
    Text scoreText;//Open a "text-shaped" box

    void Start()
    {
        scoreText = GetComponent<Text>();//Put the box that is on your object in the box
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scoreHit)
    {
        score = score + scoreHit;
        scoreText.text = score.ToString();
        print(score);
    }
}
