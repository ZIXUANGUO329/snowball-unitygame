using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Score Settings")]
    public int skiPoleScoreValue = 1000;
    private int skiPoleScore = 0;

    void Awake()
    {
        Instance = this;
    }

    public int GetCurrentScore()
    {
        int distanceScore = Mathf.RoundToInt(GameManager.Instance.distanceTraveled);
        return skiPoleScore + distanceScore;
    }

    public void AddSkiPoleScore()
    {
        skiPoleScore += skiPoleScoreValue;
    }
}
