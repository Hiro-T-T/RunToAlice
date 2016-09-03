using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlackJuck : MonoBehaviour {


    public void OnClick()
    {
        ModeManager.gameMode = 1;
        SceneManager.LoadScene("game1");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
