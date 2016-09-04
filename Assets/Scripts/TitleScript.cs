using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : Client
{
    private bool connectserver = false;
    public Toggle toggle;
    public int ClientNum = 0;
    private bool isFirstCall = true;

    public static TitleScript Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        MessageReceived += ClientNumReceived;
    }

    public void OnClick()
    {
        if (connectserver == false)
        {
            MessageReceived -= ClientNumReceived;
            SceneManager.LoadScene("mode");
        }
        else
        {
            if (ConnectionStart())
            {
                if (isFirstCall)
                {
                    //StartCoroutine(StartReadLoop());
                    isFirstCall = false;
                }

                StartCoroutine(WaitForConnecting());
            }
            else
            {
                Debug.Log("サーバに接続できませんでした");
            }
        }
    }

    private IEnumerator WaitForConnecting()
    {
        while (true)
        {
            RequestClientNum();
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(StartReading());

            if (ClientNum == 2)
            {
                MessageReceived -= ClientNumReceived;
                SceneManager.LoadScene("mode");
            }
            else
            {
                Debug.Log("サーバに接続できませんでした ClientNum : " + ClientNum);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void isOn()
    {
        if (toggle != null)
        {
            connectserver = toggle.isOn;
            Debug.Log(connectserver);
        }
    }

    private void ClientNumReceived(string num)
    {
        print("numreceived" + num);
        ClientNum = int.Parse(num);
    }
}
