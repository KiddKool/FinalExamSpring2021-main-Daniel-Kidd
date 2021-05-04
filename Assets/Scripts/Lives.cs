using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int lifeDisplay = 9;
    public Text lives;

    public void AddLives()
    {
        lifeDisplay += 1;
        lives.text = lifeDisplay.ToString();
    }

    public void RemoveLives()
    {
        lifeDisplay -= 1;
        lives.text = lifeDisplay.ToString();
    }
}
