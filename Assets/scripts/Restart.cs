using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text score;
    public ScoreManager sm;

    private void Start()
    {
        score.text = ("Ваш счёт: ") + sm.score.ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
