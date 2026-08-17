using JetBrains.Annotations;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("speed settings")]
    public float scrollSpeed = 8f;
    
    void Awake()
    {
        Instance = this;
    }
}
