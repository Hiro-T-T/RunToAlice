using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : Client
{
    private bool connectserver = false;
    public Toggle toggle;

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

    public void OnClick()
    {
        if (connectserver == false)
        {
            SceneManager.LoadScene("mode");
        }
        else
        {
            if (ConnectionStart())
            {
                StartCoroutine(StartReading());
                SceneManager.LoadScene("mode");
            }
            else
            {
                Debug.Log("サーバに接続できませんでした");
            }
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
}
