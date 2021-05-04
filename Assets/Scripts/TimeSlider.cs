using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    public Text TimeSetter;
    public static float timeValue;

    void Start()
    {
        timeValue = Timer.timeScale;
    }


    void FixedUpdate()
    {
        TimeSetter.text = timeValue.ToString("00");
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
    }
}
