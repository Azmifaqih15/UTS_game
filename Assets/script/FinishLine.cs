using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    private bool raceFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (raceFinished)
            return;

        LapTracker lap = other.GetComponent<LapTracker>();

        if (lap == null)
            return;

        // Belum melewati checkpoint
        if (!lap.passedCheckpoint)
            return;

        raceFinished = true;

        Time.timeScale = 0f;

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER MENANG");

            winPanel.SetActive(true);
        }
        else if (other.CompareTag("AI"))
        {
            Debug.Log("PLAYER KALAH");

            losePanel.SetActive(true);
        }
    }
}