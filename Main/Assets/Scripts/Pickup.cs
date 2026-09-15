using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType {Snowflake, SkiPole}
    public PickupType type;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Growthcontroller growth = other.GetComponent<Growthcontroller>();
            if (type == PickupType.Snowflake )
            {
                growth.CollectSnowflake();
            }
            else if (type == PickupType.SkiPole)
            {
                growth.CollectSkiPole();
            }

            Destroy(gameObject);
        }
    }
}
