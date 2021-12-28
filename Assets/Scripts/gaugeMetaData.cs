using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaugeMetaData : MonoBehaviour
{
    public System.DateTime lastUpdateTime;
    public List<System.DateTime> updateTimes;
    public double latitude;
    public double longitude;
    public double altitude;
    public bool latLonAltitudeAccessible = false;

    bool altAccessible = false;
    bool latAccessible = false;
    bool lonAccessible = false;
    // Start is called before the first frame update
    void Awake()
    {
        lastUpdateTime = System.DateTime.Now;
        updateTimes = new List<System.DateTime>();
        updateTimes.Add(lastUpdateTime);        
        StartCoroutine(inputAltitude());
        StartCoroutine(inputLatitudeLongitude());
    }

    IEnumerator inputAltitude()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            yield break;

        // Starts the location service.
        Input.location.Start();

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current altitude and displays it in the Console window.
            print("Altitude: " + Input.location.lastData.altitude);
        }
        altitude = Input.location.lastData.altitude;
        altAccessible = true;
        if (latAccessible && lonAccessible)
        {
            latLonAltitudeAccessible = true;
        }
    }
    IEnumerator inputLatitudeLongitude()
    {
        if (!NativeToolkit.StartLocation()) {
            yield break;
        }
        latitude = NativeToolkit.GetLatitude();
        longitude = NativeToolkit.GetLongitude();
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        if (latitude != 0 && longitude != 0)
        {
            latAccessible = true;
            lonAccessible = true;
            if (altAccessible)
            {
                latLonAltitudeAccessible = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
