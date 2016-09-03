using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : Client
{
    private bool connectserver = false;
    public Toggle toggle;

    public void OnClick()
    {
        if (connectserver == false)
        {
            SceneManager.LoadScene("game1");
        }
        else
        {
            if (ConnectionStart())
            {
                SceneManager.LoadScene("game1");
                StartCoroutine(StartReading());
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
