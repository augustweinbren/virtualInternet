using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastRefreshGauge : MonoBehaviour
{
    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("raycastRefreshGauge Mouse button dwn");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("raycastRefreshGauge Ray cast");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("raycastRefreshGauge Ray cast hit");
                if (hit.distance < 2.0f)
                {
                    Debug.Log("raycastRefreshGauge Ray cast hit distance");
                    if (hit.collider.gameObject.tag == "gauge")
                    {
                        Debug.Log("raycastRefreshGauge Ray cast hit distance tag gauge");
                        Debug.Log("raycast hit object with name = " + hit.collider.gameObject.name);
                        Debug.Log("Child 2 is named" + hit.collider.gameObject.transform.GetChild(2).gameObject.name);
                        string timestampText = hit.collider.gameObject.transform.GetChild(2).gameObject.GetComponent<showTimeStamp>().timeStamp.text;
                        Debug.Log("string initiated" + "  " + timestampText);
                        if (timestampText == "")
                        {
                            Debug.Log("text empty");
                            Debug.Log("Time to print: " + hit.collider.gameObject.transform.GetChild(2).gameObject.GetComponent<showTimeStamp>().timeToPrint);
                            timestampText = hit.collider.gameObject.transform.GetChild(2).gameObject.GetComponent<showTimeStamp>().timeToPrint;
                        }
                        else
                        {
                            Debug.Log("Text full");
                            timestampText = "";
                        }

                    }
                    else { GetComponent<hitPose>().spawnObject(); }
                }
            }
        }
    }
}
