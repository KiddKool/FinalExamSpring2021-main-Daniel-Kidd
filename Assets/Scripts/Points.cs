using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public static int newPoints = 0;
    public Text pointdisplay;

    public void AddPoints()
    {
        newPoints += 1;
        pointdisplay.text = newPoints.ToString();
    }

    public void RemovePoints()
    {
        newPoints -= 1;
        pointdisplay.text = newPoints.ToString();
    }

    public void Score()
    {
        PlayerPrefs.SetInt("Score", newPoints);
    }

    public void ScoreGrab()
    {
        pointdisplay.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
