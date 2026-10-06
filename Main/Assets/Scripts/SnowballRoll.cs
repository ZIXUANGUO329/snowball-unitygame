using UnityEngine;

public class SnowballRoll : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeedMultiplier = 1.0f; // Adjust this value to control the rotation speed
    

    void Update()
    {
        transform.Rotate(Vector3.right, GameManager.Instance.scrollSpeed * rotationSpeedMultiplier * Time.deltaTime);
    }
}
