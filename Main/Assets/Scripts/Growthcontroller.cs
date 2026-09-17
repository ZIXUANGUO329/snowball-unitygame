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

    [Header("Pickup Settings")]
    public int snowflakePerStage = 30;
    private int snowflakeCount = 0;
   

    [Header("Ability Settings")]
    public float giantSize = 12f; // Size when the ability is activated
    public bool isAbilityActive = false; // Flag to check if the ability is active
    private GrowthStage preAbilityStage; // Store the stage before the ability was activated
    private PlayerController playerController; // Reference to the PlayerController script
    public Transform cameraTransform; // Reference to the camera transform
    public Vector3 giantCameraOffset = new Vector3(0f, 8f, -16f); // Offset for the camera when in giant mode
    private Vector3 normalCameraOffset;
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        playerController = GetComponent<PlayerController>();

        if (cameraTransform != null)
        {
            normalCameraOffset = cameraTransform.localPosition; // Store the normal camera offset
        }
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

    public void ActivateGiantMode()
    {
        playerController.ResetToCenterLane(); // Reset the player to the center lane when activating the ability
        preAbilityStage = currentStage; // Store the current stage before activating the ability
        isAbilityActive = true;

        modelTransform.localScale = Vector3.one * giantSize; // Set the model size to giant size
        sphereCollider.radius = giantSize / 2f; // Adjust the collider size for giant mode

        if(cameraTransform != null)
        {
            cameraTransform.localPosition = giantCameraOffset; // Adjust the camera position for giant mode
        }
    }

    public void DeactivateGiantMode()
    {
        isAbilityActive = false;
        currentStage = preAbilityStage; // Restore the stage to what it was before the ability
        ApplySize(); // Apply the size based on the restored stage

        if(cameraTransform != null)
        {
            cameraTransform.localPosition = normalCameraOffset; // Restore the camera position to normal
        }
    }

    public void CollectSnowflake()
    {
        snowflakeCount++; 

        if (snowflakeCount >= snowflakePerStage)
        {
            snowflakeCount = 0;
            Grow();
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
            if (isAbilityActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                TakeHit();
                Destroy(other.gameObject);
            }
        }
    }
    
}
