using UnityEngine;

public class FinishLinev2 : MonoBehaviour
{
    public int totalLaps = 3;

    private int currentLap = 0;

    private bool raceStarted = false;

    private float raceTimer = 0f;

    public GameObject winUI;

    void Update()
    {
        if (raceStarted)
        {
            raceTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start race
            if (!raceStarted)
            {
                raceStarted = true;

                currentLap = 1;

                raceTimer = 0f;

                Debug.Log("Race Started!");
                Debug.Log("Lap " + currentLap + "/" + totalLaps);
            }
            else
            {
                currentLap++;

                // Finish race
                if (currentLap > totalLaps)
                {
                    Debug.Log("FINISH!");

                    Debug.Log("Total Waktu: " + raceTimer.ToString("F2") + " detik");

                    // Tampilkan UI YOU WIN
                    if (winUI != null)
                    {
                        winUI.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("Lap " + currentLap + "/" + totalLaps);
                }
            }
        }
    }
}