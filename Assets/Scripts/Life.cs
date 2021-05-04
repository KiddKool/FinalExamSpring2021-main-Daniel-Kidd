using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Dropdown dropdown;
    public static int lives;

    public void LifeMenu()
    {
        switch (dropdown.value)
        {
            case 1:
                PlayerPrefs.SetInt("Lives", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Lives", 2);
                break;
            case 3:
                PlayerPrefs.SetInt("Lives", 3);
                break;
            case 4:
                PlayerPrefs.SetInt("Lives", 4);
                break;
            case 5:
                PlayerPrefs.SetInt("Lives", 5);
                break;
            case 6:
                PlayerPrefs.SetInt("Lives", 6);
                break;
            case 7:
                PlayerPrefs.SetInt("Lives", 7);
                break;
            case 8:
                PlayerPrefs.SetInt("Lives", 8);
                break;
            case 9:
                PlayerPrefs.SetInt("Lives", 9);
                break;
        }
    }


}
