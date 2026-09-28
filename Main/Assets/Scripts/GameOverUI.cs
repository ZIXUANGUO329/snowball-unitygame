using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Shop Panel")]
    public GameObject shopPanel;
    public TMP_Text currencyText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
    }

    public void OnSubmitName()
    {
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        int finalScore = ScoreManager.Instance.GetCurrentScore();

        LeaderboardManager.Instance.SaveScore(playerName, finalScore);
        gameOverPanel.SetActive(false);
        ShowLeaderboard();
        
    }

    void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);

        string display = "";
        List<ScoreEntry> entries = LeaderboardManager.Instance.GetLeaderboard();
        for(int i = 0; i < entries.Count; i++)
        {
            display += (i + 1) + ". " + entries[i].playerName + " - " + entries[i].score + "\n";
        }

        leaderboardText.text = display;
    }

    public void OpenShop()
    {
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(true);
        UpdateCurrencyText();

    }

    public void UpdateCurrencyText()
    {
        currencyText.text = "Snowflakes: " + MetaProgressManager.Instance.currency;
    }

    public void OnBuyDash()
    {
        MetaProgressManager.Instance.PurchaseDash();
        UpdateCurrencyText();
    }

    public void OnBuySpeedBoost()
    {
        MetaProgressManager.Instance.PurchaseSpeedBoost();
        UpdateCurrencyText();
    }

    public void OnBuyBiggerStart()
    {
        MetaProgressManager.Instance.PurchaseBiggerStart();
        UpdateCurrencyText();
    }
}
