using UnityEngine;
using System.Collections;

public class TrapGenerator : MonoBehaviour {
	public float interval = 5.0f;
	private float timeLeft;
	public GameManager gm;
	public GameObject Batsu;
	public GameObject MushiMegane;
	public GameObject Reverse;

	// Use this for initialization
	void Start () {
		timeLeft = interval;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0)
		{
			timeLeft = interval;

			int rand = Random.Range(0, 3);
			//ここに処理
			if(rand == 0)
			{
				Instantiate(Batsu, new Vector3(Random.Range(gm.minPos, gm.maxPos), 0.05f, 42), Quaternion.identity);
			}
			else if (rand == 1)
			{
				Instantiate(MushiMegane, new Vector3(Random.Range(gm.minPos, gm.maxPos), 0.05f, 42), Quaternion.identity);
			}
			else
			{
				Instantiate(Reverse, new Vector3(Random.Range(gm.minPos, gm.maxPos), 0.05f, 42), Quaternion.identity);
			}
		}
	}
}
