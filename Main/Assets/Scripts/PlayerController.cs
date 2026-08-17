using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Lane Settings")]
    public float laneDistance = 4.5f; // The distance between two lanes
    private int currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right

    [Header("Movement Settings")]
    //public float forwardSpeed = 8f; // The speed at which the player moves forward
    public float laneChangeSpeed = 10f; // The speed at which the player changes lanes

    [Header("Jump Settings")]
    public float jumpForce = 10f; // The force applied when the player jumps
    private bool isGrounded = true; // Whether the player is on the ground or not
    public float fallSpeed = 2.5f; // The speed at which the player falls down

    private Rigidbody rb;
    private float targetPositonX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPositonX = transform.position.x;
    }


    void Update()
    {
        HandleLaneInput();
        HandleJumpInput();
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
    void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        float newX = Mathf.MoveTowards(rb.position.x, targetPositonX, laneChangeSpeed * Time.fixedDeltaTime);
        Vector3 newPosition = new Vector3(newX, rb.position.y, rb.position.z);
        rb.MovePosition(newPosition);
        
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallSpeed - 1f) * Time.fixedDeltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}