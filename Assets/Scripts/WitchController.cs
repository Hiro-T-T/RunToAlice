using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour {

    public float attackTime = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0.0)
        {
            attackTime = 3.0f;
            Attack();
            //ここに処理

        }
    }

    void Attack()
    {
        //Instantiate();
    }
}
