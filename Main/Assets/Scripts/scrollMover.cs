using UnityEngine;

public class scrollMover : MonoBehaviour
{
    public float destroyZ = -10f;
    void Update()
    {
        float speed = GameManager.Instance.scrollSpeed;
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }

}   
    
