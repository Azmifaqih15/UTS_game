using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LapTracker lapTracker = other.GetComponent<LapTracker>();

        if (lapTracker != null)
        {
            lapTracker.passedCheckpoint = true;

            Debug.Log("Checkpoint Tercapai!");
        }
    }
}