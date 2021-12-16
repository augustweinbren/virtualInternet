using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rssiReceiver : MonoBehaviour
{
    public float rssi;
    public pingTest ping;


        private float m_msg;
    
    public float msg
    {
        get
        {
            return m_msg;
        }
        set
        {
            if (m_msg == value) return;
            m_msg = value;
            if (OnMessageArrived != null)
            {
                OnMessageArrived(m_msg);
            }
        }
    }
    public event OnMessageArrivedDelegate OnMessageArrived;
    public delegate void OnMessageArrivedDelegate(float newMsg);

    // Start is called before the first frame update

    public IEnumerator rssiCoroutine()
    {
        float inputPing = ping.msg;
        Debug.Log("inputPing: " + inputPing);
        rssi = 100f - inputPing + Random.Range(-20f, 20f);
        Debug.Log("rssi: " + rssi);
        if (rssi > 100) {
            rssi = 100f;
        } else if (rssi < 0) {
            rssi = 0f;
        }
        msg = rssi;
        yield return null;
    }

    public void startRSSICoroutine()
    {
        StartCoroutine(rssiCoroutine());
    }
}
