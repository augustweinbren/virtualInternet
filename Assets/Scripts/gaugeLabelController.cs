using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaugeLabelController : MonoBehaviour
{
    public gaugeMetaData gaugeMetaData;
    public TMPro.TextMeshPro gaugeLabel;
    // Start is called before the first frame update
    void Start()
    {
        gaugeLabel = GetComponent<TMPro.TextMeshPro>();
        gaugeLabel.text = "";
    }

    public void printMetaData() {
        if (gaugeMetaData.latLonAltitudeAccessible) {
            gaugeLabel.text = "Internet speed most recently tested here at: " +
            gaugeMetaData.lastUpdateTime.ToString(
                "MM/dd/yyyy HH:mm:ss") + "\n" +
                "Latitude: " + gaugeMetaData.latitude.ToString() + "\n" +
                "Longitude: " + gaugeMetaData.longitude.ToString() + "\n" +
                "Altitude: " + gaugeMetaData.altitude.ToString();
        } else {
            gaugeLabel.text = "Most recent internet speed test: " +
            gaugeMetaData.lastUpdateTime.ToString(
                "MM/dd/yyyy HH:mm:ss");
        }
    }

    public void hideMetaData() {
        gaugeLabel.text = "";
    }
}
