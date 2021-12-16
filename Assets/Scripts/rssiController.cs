using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rssiController : MonoBehaviour
{
    public string nameController = "RSSI Controller";
    public string tagOfTheRssiReceiver = "";
    public GameObject objectToControl;
    private float numValue = 0.0f;
    public rssiReceiver _eventSender;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfTheRssiReceiver).Length > 0) {
            _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheRssiReceiver)[0].gameObject.
            GetComponent<rssiReceiver>();
        }
        else {
            Debug.LogError("At least one GameObject with rssiReceiver component and Tag == tagOfTheRssiReceiver needs to be provided");
        }
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;   
    }

    private void OnMessageArrivedHandler(float newMsg)
    {
        numValue = newMsg;
        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + numValue.ToString());
        
    }

    // Update is called once per frame
    private void Update()
    {
        float step = 0.5f * Time.deltaTime;

        Vector3 rotationVector = new Vector3(objectToControl.transform.localEulerAngles.x, objectToControl.transform.localEulerAngles.y, numValue * 1.8f);

        objectToControl.transform.localRotation = Quaternion.Lerp(objectToControl.transform.localRotation, Quaternion.Euler(rotationVector), step);

    }
}
