using UnityEngine;

public class PickupSpin : MonoBehaviour
{
    
    public float rotationSpeed = 100f; // Adjust this value to control the rotation speed
    public Vector3 rotationAxis = Vector3.up; // Default rotation axis is Y-axis

    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
