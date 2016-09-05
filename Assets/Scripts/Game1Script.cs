using UnityEngine;
using System.Collections;

public class Game1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(Resources.Load("alice"));
        Instantiate(Resources.Load("background"));
        Instantiate(Resources.Load("background"), new Vector3(0, 0, 10), Quaternion.identity);
        Instantiate(Resources.Load("background"), new Vector3(0, 0, 20), Quaternion.identity);
        Instantiate(Resources.Load("background"), new Vector3(0, 0, 30), Quaternion.identity);
        Instantiate(Resources.Load("background"), new Vector3(0, 0, 40), Quaternion.identity);
        Instantiate(Resources.Load("background"), new Vector3(0, 0, 50), Quaternion.identity);
        Instantiate(Resources.Load("endWall"));
        Instantiate(Resources.Load("game1_canvas"));
        Instantiate(Resources.Load("GameManager"));
        

    }

    // Update is called once per frame
    void Update () {
	
	}
}
