
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Lane Settings")]
    public float laneDistance = 4.5f; // The distance between two lanes
    private int currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right

    [Header("Movement Settings")]
    //public float forwardSpeed = 8f; // The speed at which the player moves forward
    public float laneChangeSpeed = 10f; // The speed at which the player changes lanes


    private Rigidbody rb;
    private float targetPositonX;
    private Growthcontroller growth;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        growth = GetComponent<Growthcontroller>();
        targetPositonX = transform.position.x;
    }


    void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        if (growth.isAbilityActive) return; // Disable input when the ability is active

        HandleLaneInput();
        
    }
    void HandleLaneInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(1);
        }
    }

    void ChangeLane(int direction)
    {
        int newLane = currentLane + direction;
        newLane = Mathf.Clamp(newLane, 0, 2); // Ensure the new lane is within bounds
        currentLane = newLane;
        targetPositonX = (currentLane - 1) * laneDistance; // Calculate the new target position based on the lane
    }

    public void ResetToCenterLane()
    {
        currentLane = 1; // Reset to the middle lane
        targetPositonX = 0f; // Reset the target position to the center
        rb.position = new Vector3(0f , rb.position.y, rb.position.z); // Move the player to the center lane immediately
    }
    
    
    void FixedUpdate()
    {
        float newX = Mathf.MoveTowards(rb.position.x, targetPositonX, laneChangeSpeed * Time.fixedDeltaTime);
        Vector3 newPosition = new Vector3(newX, rb.position.y, rb.position.z);
        rb.MovePosition(newPosition);
        
    }
   
}
