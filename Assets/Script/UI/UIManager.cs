using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_livesText;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    [SerializeField] private int m_lives = 3;
    [SerializeField] private int m_score = 0;

    void Start()
    {
        UpdateLivesText();
        UpdateScoreText();
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
