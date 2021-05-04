using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public InputField input;
    public static string currentName;


    public void getName()
    {

        currentName = input.text;
    }
}
