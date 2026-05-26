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
        if (other.CompareTag("Player"))
        {
            // Pertama kali melewati garis start
            if (!hasStartedLap)
            {
                hasStartedLap = true;

                lapTimer = 0f;

                Debug.Log("Lap Dimulai!");
            }
            else
            {
                // Finish setelah 1 putaran
                Debug.Log("FINISH!");

                Debug.Log("Waktu Tempuh: " + lapTimer.ToString("F2") + " detik");

                // Tampilkan UI YOU WIN
                if (winUI != null)
                {
                    winUI.SetActive(true);
                }

                // Pindah level setelah delay
                StartCoroutine(NextLevel());
            }
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(nextLevelDelay);

        SceneManager.LoadScene("level 2");
    }
}