using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
    private TitleScript ts;
    public GameObject br;
    public GameObject instantiateImage;
    public GameManager gm;
    private GameObject obstacle;
    public float minPos = -4.0f;
    public float maxPos = 4.0f;

    // Use this for initialization
    void Start()
    {
        obstacle = (GameObject)Resources.Load("Obstacle");
        ts = TitleScript.Instance;
        br = GameObject.Find("braver");

        if (ts != null)
        {
            print("StartNetworkManager");
            ts.AtButtonReceived += AtButtonReceived;
            ts.MessageReceived += MessageReceived;
            StartCoroutine(ts.StartReadLoop());
            // StartSendInfo();
            //print("StartSendInfo");
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
                StartCoroutine(ts.SendMessage("pressatb "+ Random.Range(minPos, maxPos)));
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

    private void AtButtonReceived(string str)
    {
        print("Button Pressed : " + float.Parse(str));
        Instantiate(obstacle, new Vector3(float.Parse(str), 0, 42), Quaternion.identity);
    }

}
