using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public TextMeshProUGUI scoreDisplayUI;

    void Update()
    {
        scoreDisplay.text = "Счет: " + score.ToString();
        scoreDisplayUI.text = "Счет: " + score.ToString();
    }

    public void Kill()
    {
        score++;
    }
}
