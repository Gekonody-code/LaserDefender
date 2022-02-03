using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;

    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    private void Update()
    {
        UpdateHealth();
        UpdateScoreText();
    }

    public void UpdateHealth()
    {
        healthSlider.value = playerHealth.GetHealth();
    }

    public void UpdateScoreText()
    {
        scoreText.text = scoreKeeper.getScore().ToString("000000000");
    }
}
