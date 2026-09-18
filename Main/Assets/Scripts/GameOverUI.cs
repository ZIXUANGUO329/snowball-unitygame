using UnityEngine;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    [Header("Game Over Panel")]
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public TMP_InputField nameInputField;

    [Header("Leaderboard Panel")]
    public GameObject leaderboardPanel;
    public TMP_Text leaderboardText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
    }
}
