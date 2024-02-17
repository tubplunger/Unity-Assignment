using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            setTimerText();
            timerText.color = Color.red;
            enabled = false;
        }
        setTimerText();
    }

    private void setTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}
