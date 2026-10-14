using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Growthcontroller playerGrowth;

    [Header("UI References")]
    public GameObject startPanel;
    [Header("speed settings")]
    public float scrollSpeed = 8f;

    [Header("status")]
    public bool isGameOver = false;
    private static bool hasPlayedBefore = false;

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

        if (hasPlayedBefore)
        {
            // Not the first time (scene was reloaded via Restart) - skip the start screen
            startPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            // First time launching - show the start screen and pause
            Time.timeScale = 0f;
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

    public void StartGame()
    {
        hasPlayedBefore = true;
        Time.timeScale = 1f; // Resume the game
        startPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

