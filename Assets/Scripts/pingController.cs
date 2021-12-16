using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingController : MonoBehaviour
{
    public string nameController = "Ping Controller";
    public string tagOfThePingTest = "";
    public GameObject objectToControl;
    private float numValue = 0.0f;
    public pingTest _eventSender;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfThePingTest).Length > 0) {
            _eventSender = GameObject.FindGameObjectsWithTag(tagOfThePingTest)[0].gameObject.
            GetComponent<pingTest>();
        }
        else {
            Debug.LogError("At least one GameObject with pingTest component and Tag == tagOfThePingTest needs to be provided");
        }
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;   
    }

    private void OnMessageArrivedHandler(float newMsg)
    {
        numValue = newMsg;
        Debug.Log("Event Fired. The Ping Test message, from Object " + nameController + " is = " + numValue.ToString());
        
    }

    // Update is called once per frame
    private void Update()
    {
        float step = 0.5f * Time.deltaTime;

        Vector3 rotationVector = new Vector3(objectToControl.transform.localEulerAngles.x, objectToControl.transform.localEulerAngles.y, -numValue * 1.8f);

        objectToControl.transform.localRotation = Quaternion.Lerp(objectToControl.transform.localRotation, Quaternion.Euler(rotationVector), step);

    }
}
