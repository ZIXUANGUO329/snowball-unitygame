using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioClip collectSnowflakeClip;
    public AudioClip collectSkiPoleClip;
    public AudioClip hitObstacleClip;
    public AudioClip giantModeClip;
    public AudioClip BaseToStage1;
    public AudioClip Stage1ToStage2;
    public AudioClip gameOverClip;
    public AudioClip uiClickClip;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bgmSource.Play();
    }

    public void PlayCollectSnowflakeSound()
    {
        sfxSource.PlayOneShot(collectSnowflakeClip);
    }
    public void PlayCollectSkiPoleSound()
    {
        sfxSource.PlayOneShot(collectSkiPoleClip);
    }
    public void PlayHitObstacleSound()
    {
        sfxSource.PlayOneShot(hitObstacleClip);
    }
    public void PlayGiantModeSound()
    {
        sfxSource.PlayOneShot(giantModeClip);
    }
    public void PlayBaseToStage1Sound()
    {
        sfxSource.PlayOneShot(BaseToStage1);
    }
    public void PlayStage1ToStage2Sound()
    {
        sfxSource.PlayOneShot(Stage1ToStage2);
    }
    public void PlayGameOverSound()
    {
        sfxSource.PlayOneShot(gameOverClip);
    }
    public void PlayUIClickSound()
    {
        sfxSource.PlayOneShot(uiClickClip);
    }
}