using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore = 0;

    static ScoreKeeper instance;
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if (instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getScore()
    {
        return currentScore;
    }

    public void addScore(int points)
    {
        currentScore += points;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

    public void resetScore()
    {
        currentScore = 0;
    }
}
