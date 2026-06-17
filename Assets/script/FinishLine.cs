using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishLine : MonoBehaviour
{
    private bool hasStartedLap = false;
    private float lapTimer = 0f;

    public GameObject winUI;
    public float nextLevelDelay = 3f;

    void Update()
    {
        if (hasStartedLap)
        {
            lapTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Hanya Player yang dihitung
        if (!other.CompareTag("Player"))
            return;

        LapTracker lapTracker = other.GetComponent<LapTracker>();

        if (lapTracker == null)
            return;

        // Pertama kali melewati garis finish
        if (!hasStartedLap)
        {
            hasStartedLap = true;
            lapTimer = 0f;

            Debug.Log("Lap Dimulai!");

            return;
        }

        // Harus sudah melewati checkpoint
        if (!lapTracker.passedCheckpoint)
            return;

        lapTracker.passedCheckpoint = false;

        Debug.Log("YOU WIN!");
        Debug.Log("Waktu Tempuh: " + lapTimer.ToString("F2") + " detik");

        if (winUI != null)
        {
            winUI.SetActive(true);
        }

        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(nextLevelDelay);

        SceneManager.LoadScene("level 2");
    }
}