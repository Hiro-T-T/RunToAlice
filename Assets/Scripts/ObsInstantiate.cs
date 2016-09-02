using UnityEngine;
using System.Collections;

public class ObsInstantiate : MonoBehaviour {

    public GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
    void Update()
    {
        gm.timeLeft -= Time.deltaTime;
        if (gm.timeLeft <= 0.0)
        {
            gm.timeLeft = 3.0f;
            gm.Create(gm);
            //ここに処理
            //GameObject obs = Instantiate(obstacle, new Vector3(Random.Range(minPos, maxPos), 0, 42), Quaternion.identity) as GameObject;
        }
    }
}
