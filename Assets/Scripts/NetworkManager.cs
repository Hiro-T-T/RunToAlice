using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
    private TitleScript ts;
    public GameObject ar;
    public GameObject instantiateImage;
    public GameManager gm;
    public GameObject obstacle = null;
    public float minPos = -4.0f;
    public float maxPos = 4.0f;

    public static PlayerInfo RivalInfo;

    // Use this for initialization
    void Start()
    {
        ts = TitleScript.Instance;
        ar = GameObject.Find("alice");

        if (ts != null)
        {
            print("StartNetworkManager");
            ts.AtButtonReceived += AtButtonReceived;
            ts.MessageReceived += MessageReceived;
            StartCoroutine(ts.StartReadLoop());
            StartSendInfo();
            //print("StartSendInfo");
            StartCoroutine(GenerateLoop());
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

            PlayerInfo pi = new PlayerInfo(CharacterController.hp, ar.transform.position.x, ar.transform.position.y);
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
            StartCoroutine(ts.SendMessage("pressatb " + Random.Range(minPos, maxPos)));
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
        RivalInfo = JsonUtility.FromJson<PlayerInfo>(message);
    }

    private void AtButtonReceived(string str)
    {
        print("Button Pressed : " + float.Parse(str));
        //if (obstacle != null)
        objectX = float.Parse(str);
        isReceived = true;
    }

    private float objectX;
    private bool isReceived = false;
    private IEnumerator GenerateLoop()
    {
        while (true)
        {
            if (isReceived)
            {
                GameObject prefab = Resources.Load<GameObject>("Obstacle");
                GameObject obs = Instantiate(prefab, new Vector3(Random.Range(gm.minPos, gm.maxPos), 1.6f, 42), prefab.transform.rotation) as GameObject;
                obs.GetComponent<Obstacle>().CardNum = Random.Range(1, 14);
                obs.GetComponent<Obstacle>().State = gm.obsState;
            }
            isReceived = false;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
