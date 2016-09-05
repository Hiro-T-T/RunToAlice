using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    public GameObject MyHP;
    public GameObject RivalHP;
    public GameObject WinLose;
    private string MyName;
    private string RivalName;
    private int MyHp;
    private int RivalHp;

    // Use this for initialization
    void Start()
    {
        MyName = TitleScript.PlayerName;
        MyHp = CharacterController.hp;
        if (NetworkManager.RivalInfo != null)
        {
            RivalName = NetworkManager.RivalInfo.Name;
            RivalHp = NetworkManager.RivalInfo.HP;
        }
        else RivalHp = 100;
    }

    // Update is called once per frame
    void Update()
    {

        MyHP.GetComponent<Text>().text = "" + MyHp;
        RivalHP.GetComponent<Text>().text = "" + RivalHp;
        if ((MyHp < RivalHp && MyHp != 0) || RivalHp == 0)
        {
            WinLose.GetComponent<Text>().text = "You Win";
        }
        else if ((MyHp > RivalHp && RivalHp != 0) || MyHp == 0)
        {
            WinLose.GetComponent<Text>().text = "You Lose";
        }
        else
        {
            WinLose.GetComponent<Text>().text = "Draw";
        }
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("retryexit");
    }
}
