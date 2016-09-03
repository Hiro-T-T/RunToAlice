using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
    private TitleScript ts;
    public GameObject br;

    // Use this for initialization
    void Start()
    {
        ts = TitleScript.Instance;
        br = GameObject.Find("braver");

        print("StartNetworkManager");
        if (ts != null)
        {
            ts.MessageReceived += MessageReceived;
            StartSendInfo();
            print("StartSendInfo");
        }
    }

    public void StartSendInfo()
    {
        StartCoroutine(SendInfo());
    }

    private IEnumerator SendInfo()
    {
        if (ts == null) yield return null;
        while (true)
        {
            if (ts == null) break;

            PlayerInfo pi = new PlayerInfo(CharacterController.hp, br.transform.position.x, br.transform.position.y);
            ts.SendPlayerInfo(pi);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void MessageReceived(List<string> messages)
    {
        foreach(var s in messages)
        {
            print(s);
        }
    }
}
