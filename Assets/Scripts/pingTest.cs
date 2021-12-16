using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class pingTest : MonoBehaviour
{

    public string IP = "www.google.com";
    Ping ping;
    
    public rssiReceiver rssiReceiver;
    int delayTime;
    int pingCounter = 0;
    List<float> pingTimes = new List<float>();
    private float pingAvg;
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

    // void OnGUI()
    // {
    // GUI.color = Color.red;
        // GUI.Label(new Rect(10, 10, 100, 20), "ping: " + delayTime.ToString() + "ms");
    // public void run10Pings() {
    //     SendPing();
    //     if (ping != null && ping.isDone && pingCounter < 10)
    //     {
    //         pingCounter++;
    //         Debug.Log(pingCounter.ToString() + " Ping counts");
    //         SendPing();
    //         delayTime = ping.time;
    //         pingTimes.Add(ping.time);
    //         Debug.Log("ping: " + delayTime.ToString() + "ms");
    //         ping.DestroyPing();
    //         ping = null;
    //     }
    //     if (pingCounter == 10) {
    //         pingAvg = pingTimes.Average();
    //         Debug.Log("pingAvg: " + pingAvg);
    //         if (pingAvg > 100) {
    //             msg = 100f;
    //         } else { msg = pingAvg; }
    //         pingTimes.Clear();
    //     }
    // }
    IEnumerator run10PingsCoroutine() {
        int i = 0;
        SendPing();
        while (i < 10) {
        if (ping != null && ping.isDone)
        {

            i++;
            Debug.Log(i.ToString() + " Ping counts");
            delayTime = ping.time;
            pingTimes.Add(ping.time);
            Debug.Log("ping: " + delayTime.ToString() + "ms");
            ping.DestroyPing();
            ping = null;
            SendPing();
        }
        yield return null;
        }
        if (i == 10) {
            pingAvg = pingTimes.Average();
            Debug.Log("pingAvg: " + pingAvg);
            if (pingAvg > 100) {
                msg = 100f;
            } else { msg = pingAvg; }
            rssiReceiver.startRSSICoroutine();
            pingTimes.Clear();
        }
        yield return null;
    }
    public void SendPing()
    {
        ping = new Ping(IP);
    }

    public void start10RingsCoroutine() {
        StartCoroutine(run10PingsCoroutine()); 
    }
}

