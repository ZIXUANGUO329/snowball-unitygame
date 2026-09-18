using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class ScoreEntryList
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
}

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;
    public int maxEntries = 5;

    void Awake()
    {
        Instance = this;
        LoadLeaderboard();
    }

    private ScoreEntryList leaderboard;

    void LoadLeaderboard()
    {
        string json = PlayerPrefs.GetString("Leaderboard", "");

        if (string.IsNullOrEmpty(json))
        {
            leaderboard = new ScoreEntryList();
        }
        else
        {
            leaderboard = JsonUtility.FromJson<ScoreEntryList>(json);
        }
    }

    public void SaveScore(string playerName, int score)
    {
        leaderboard.entries.Add(new ScoreEntry { playerName = playerName, score = score });
        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));
        if (leaderboard.entries.Count > maxEntries)
        {
            leaderboard.entries.RemoveRange(maxEntries, leaderboard.entries.Count - maxEntries);
        }

        string json = JsonUtility.ToJson(leaderboard);
        PlayerPrefs.SetString("Leaderboard", json);
        PlayerPrefs.Save();
    }

    public List<ScoreEntry> GetLeaderboard()
    {
        return leaderboard.entries;
    }
}
