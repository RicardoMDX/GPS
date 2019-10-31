using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text txt_TimerText;
    public float fl_TimeLeft;

    void Start()
    {
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (txt_TimerText != null)
        {
            fl_TimeLeft = 600;
            txt_TimerText.text = "Time Left: 20:00:000";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (txt_TimerText != null)
        {
            fl_TimeLeft -= Time.deltaTime;
            string minutes = Mathf.Floor(fl_TimeLeft / 60).ToString("00");
            string seconds = (fl_TimeLeft % 60).ToString("00");
            txt_TimerText.text = "Time Left: " + minutes + ":" + seconds;
        }
    }
}
