using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Growthcontroller playerGrowth;

    [Header("speed settings")]
    public float scrollSpeed = 8f;

    [Header("status")]
    public bool isGameOver = false;

    [Header("Difficulty Curve")]
    public AnimationCurve difficultyCurve;
    public float distanceTraveled = 0f;
    public float difficulty = 0f;

    [Header("Speed Range")]
    public float baseSpeed = 8f;
    public float maxSpeed = 20f;
    public float speedBoostBonus = 2f;

    void Start()
    {
        if (MetaProgressManager.Instance.hasSpeedBoost is true)
        {
            baseSpeed += speedBoostBonus;
            maxSpeed += speedBoostBonus;
        }
        
    }
    void Awake()
    {
        Instance = this;
        //PlayerPrefs.DeleteAll(); //use for debugging delet all the data 
    }

    void Update()
    {
        if (isGameOver) return;
        distanceTraveled += scrollSpeed * Time.deltaTime;
        difficulty = difficultyCurve.Evaluate(distanceTraveled);
        // Adjust scroll speed based on difficulty
        scrollSpeed = Mathf.Lerp(baseSpeed, maxSpeed, difficulty);
    }
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        MetaProgressManager.Instance.AddCurrency(playerGrowth.GetTotalSnowflakesThisRun());
        scrollSpeed = 0f;
        Debug.Log("Game Over!");
        GameOverUI.Instance.ShowGameOverPanel();
    }
}

