using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timeScale = 60f;

    public void SetTime(float value)
    {
        timeScale = value;
    }
}
