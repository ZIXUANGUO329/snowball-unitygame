using UnityEngine;

public class RecycleMover : MonoBehaviour
{
    public float destroyZ = -10f;
    public float recycleDistance = 20f;
    void Update()
    {
        float speed = GameManager.Instance.scrollSpeed;
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        if (transform.position.z < destroyZ)
        {
            Vector3 pos = transform.position;
            pos.z += recycleDistance;
            transform.position = pos;
        }
    }

}


