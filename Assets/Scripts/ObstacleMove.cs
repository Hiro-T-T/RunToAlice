using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public float moveSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0,0,-moveSpeed);
        //this.transform.position = Vector3.Lerp(new Vector3(0, 0, 5), new Vector3(0, 0, -5), Time.deltaTime * 0.2f);
    }
}
