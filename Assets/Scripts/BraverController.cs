using UnityEngine;
using System.Collections;

public class BraverController : MonoBehaviour {
    ObsType obs;
	// Use this for initialization
	void Start () {
        obs = ObsType.Braver;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            GameManager.killCount++;
            Destroy(this.gameObject);
        }
    }
}
