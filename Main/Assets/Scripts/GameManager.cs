using JetBrains.Annotations;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("speed settings")]
    public float scrollSpeed = 8f;

    [Header("status")]
    public bool isGameOver = false;
    
    void Awake()
    {
        Instance = this;
    }
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        scrollSpeed = 0f;

        Debug.Log("Game Over!");
    }
}

