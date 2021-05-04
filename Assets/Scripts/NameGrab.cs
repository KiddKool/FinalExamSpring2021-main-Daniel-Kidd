using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGrab : MonoBehaviour
{


    public Text nameGrab;
    private string currentname;


    public void Start()
    {

        currentname = NameDisplay.currentName;
        Debug.Log(currentname);
    }


}