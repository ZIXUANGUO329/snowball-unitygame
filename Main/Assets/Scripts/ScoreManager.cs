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
        //Debug.Log("ScoreManager Awake work ， GameObject name： " + gameObject.name);
    }

    public int GetCurrentScore()
    {
        //Debug.Log("GetCurrentScore works, GameManager.Instance null?: " + (GameManager.Instance == null));
        int distanceScore = Mathf.RoundToInt(GameManager.Instance.distanceTraveled);
        return skiPoleScore + distanceScore;
    }

    public void AddSkiPoleScore()
    {
        skiPoleScore += skiPoleScoreValue;
    }
}
