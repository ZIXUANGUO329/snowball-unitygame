using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgmSource;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bgmSource.Play();
    }
}
