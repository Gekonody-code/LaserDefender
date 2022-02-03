using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper score;

    private void Awake()
    {
        score = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "You scored:\n" +  score.getScore();
    }

}
