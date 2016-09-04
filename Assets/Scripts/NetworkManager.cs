using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
    private TitleScript ts;
    public GameObject br;
    public GameObject instantiateImage;

    // Use this for initialization
    void Start()
    {
        ts = TitleScript.Instance;
        br = GameObject.Find("braver");

        print("StartNetworkManager");
        if (ts != null)
        {
            ts.AtButtonReceived += AtButtonReceived;
            ts.MessageReceived += MessageReceived;
            StartCoroutine(ts.StartReadLoop());
            // StartSendInfo();
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

    public void PressAttackButton()
    {
        //if (GameManager.coolTime == false)
        //{
            if (ts != null)
            {
                StartCoroutine(ts.SendMessage("pressatb"));
            }
            GameManager.coolTime = true;
            instantiateImage.SetActive(false);
            Invoke("CoolManage", GameManager.intarval);
        //}
    }

    public void CoolManage()
    {
        GameManager.coolTime = true;
        instantiateImage.SetActive(true);
    }

    private void MessageReceived(string message)
    {
        print(message);
    }

    private void AtButtonReceived()
    {
        print("Button Pressed");
    }
}
