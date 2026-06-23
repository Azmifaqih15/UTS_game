using UnityEngine;
using TMPro;
using System.Collections;

public class RaceCountdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public static bool raceStarted = false;

    IEnumerator Start()
    {
        raceStarted = false;

        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";

        raceStarted = true;

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
}