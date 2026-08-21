using Unity.VisualScripting;
using UnityEngine;

public class Growthcontroller : MonoBehaviour
{
    public enum GrowthStage { Base, Stage1, Stage2 };
    public GrowthStage currentStage = GrowthStage.Base;

    [Header("References")]
    public Transform modelTransform;
    private SphereCollider sphereCollider;

    [Header("Sizes")]
    public float baseSize = 0.3f;
    public float stage1Size = 0.45f;
    public float stage2Size = 0.65f;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        ApplySize(); 
    }

    public void Grow()
    {
        if (currentStage == GrowthStage.Base)
        { 
            currentStage = GrowthStage.Stage1;
        }
        else if (currentStage == GrowthStage.Stage1)
        {
            currentStage = GrowthStage.Stage2;
        }
        ApplySize();
    }
    
    public void TakeHit()
    {
        if (GameManager.Instance.isGameOver) return;
        if (currentStage == GrowthStage.Stage2)
        {
            currentStage = GrowthStage.Stage1;
            ApplySize();
        }
        else if (currentStage == GrowthStage.Stage1)
        {
            currentStage = GrowthStage.Base;
            ApplySize();
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }

    void ApplySize()
    {
        float diameter = baseSize;
        if (currentStage == GrowthStage.Stage1) diameter = stage1Size;
        else if (currentStage == GrowthStage.Stage2) diameter = stage2Size;

        modelTransform.localScale = Vector3.one * diameter;
        sphereCollider.radius = diameter / 2f;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            TakeHit();
            Destroy(other.gameObject);
        }
    }
    //debugging press G key to collect the coin; will delet it after 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Grow();
        }
    }
}
