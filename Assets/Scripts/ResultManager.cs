using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    public GameObject MyHP;
    public GameObject RivalHP;
    public GameObject WinLose;
    private int MyHp;
    private int RivalHp;

    // Use this for initialization
    void Start()
    {
        MyHp = CharacterController.hp;
        RivalHp = CharacterController.hp;
    }

    // Update is called once per frame
    void Update()
    {

        MyHP.GetComponent<Text>().text = "自分のHP：" + MyHp;
        RivalHP.GetComponent<Text>().text = "相手のHP：" + RivalHp;
        if (MyHp > RivalHp )
        {
            WinLose.GetComponent<Text>().text = "You Win";
        }
        else if (MyHp < RivalHp)
        {
            WinLose.GetComponent<Text>().text = "You Lose";
        }
        else
        {
            WinLose.GetComponent<Text>().text = "Draw";
        }
    }
}
