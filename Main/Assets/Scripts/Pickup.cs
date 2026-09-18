using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType {Snowflake, SkiPole}
    public PickupType type;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Growthcontroller growth = other.GetComponent<Growthcontroller>();

            if (!growth.isAbilityActive)
            {
                if (type == PickupType.Snowflake)
                {
                    growth.CollectSnowflake();
                }
                else if (type == PickupType.SkiPole)
                {
                    AbilityController ability = other.GetComponent<AbilityController>();
                    ability.CollectSkiPole();
                    ScoreManager.Instance.AddSkiPoleScore();
                }

            }
            Destroy(gameObject);
        }
    }
}
