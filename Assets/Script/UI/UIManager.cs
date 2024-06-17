using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text m_livesText;
    public Text m_scoreText;

    public int m_lives = 3;
    public int m_score = 0;

    void Start()
    {
        UpdateLivesText(); UpdateScoreText();
    }
    public void UpdateLives(int newLives)
    {
        m_lives = newLives; UpdateLivesText();
    }
    public void UpdateScore(int newPoints)
    {
        m_score = newPoints; UpdateScoreText();
    }
    private void UpdateLivesText()
    {
        m_livesText.text = "Lives:  " + m_lives.ToString();
    }
    private void UpdateScoreText()
    {
        m_scoreText.text = "Points:  " + m_score.ToString();
    }
}
