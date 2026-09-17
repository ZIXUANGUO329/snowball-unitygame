using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType {Snowflake, SkiPole}
    public PickupType type;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (type == PickupType.Snowflake)
            {
                Growthcontroller growth = other.GetComponent<Growthcontroller>();
                growth.CollectSnowflake();
            }
            else if (type == PickupType.SkiPole)
            {
                AbilityController ability = other.GetComponent<AbilityController>();
                ability.CollectSkiPole();
            }

            Destroy(gameObject);
        }
    }
}
