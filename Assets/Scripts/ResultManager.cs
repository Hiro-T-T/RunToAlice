using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

    public GameObject tex;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (ModeManager.gameMode == 1)
        {
            tex.GetComponent<Text>().text = "You are BluckJuck";
        }

        if (ModeManager.gameMode == 2)
        {
            tex.GetComponent<Text>().text = ((int)CharacterController.hp).ToString();
        }

    }
}
