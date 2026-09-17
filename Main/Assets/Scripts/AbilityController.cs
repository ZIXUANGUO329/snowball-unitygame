using UnityEngine;
using System.Collections;
public class AbilityController : MonoBehaviour
{
    public float abilityDuration = 5f; // Duration of the ability in seconds
    public int skiPoleSlots = 3; // Number of ski pole slots available
    private int skiPoleCount = 0; // Current number of ski poles collected
    public Growthcontroller growth;
    public void CollectSkiPole()
    {

        skiPoleCount++;
        if (skiPoleCount >= skiPoleSlots)
        {
            skiPoleCount = 0; // Reset the count after reaching the limit
            StartCoroutine(RunAbility());
        }

    }
    IEnumerator RunAbility()
    {
        growth.ActivateGiantMode();
        yield return new WaitForSeconds(abilityDuration);
        growth.DeactivateGiantMode();
    }
}
