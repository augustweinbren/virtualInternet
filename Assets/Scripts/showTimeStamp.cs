using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showTimeStamp : MonoBehaviour
{

    public string timeToPrint;
    public TMPro.TextMeshPro timeStamp;
    public hitPose hitPose;

    void Awake() {
        timeStamp = GetComponent<TMPro.TextMeshPro>();
    }
    public void updateTMPro() {
        timeStamp.text = timeToPrint;
    }
    public void hideTMPro() {
        timeStamp.text = "";
    }
}
