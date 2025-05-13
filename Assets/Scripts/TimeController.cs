using UnityEngine;
using TMPro;
using System.Collections;


public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float actualTime;
    private float minutes;
    private float seconds;
    private bool isGameActive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualTime = 0;
        StartCoroutine(TimerCountUp());
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;

    }

    IEnumerator TimerCountUp()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(0.2f);
            minutes = Mathf.Floor(actualTime / 60);
            seconds = actualTime % 60;
            if (seconds > 59) seconds = 59;
            if (minutes < 0)
            {
                minutes = 0;
                seconds = 0;
            }
            timeText.text = string.Format(" TIME: {0:0} : {1:00}", minutes, seconds);
        }



    }
}
