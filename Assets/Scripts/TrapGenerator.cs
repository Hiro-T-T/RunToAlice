using UnityEngine;
using System.Collections;

public class TrapGenerator : MonoBehaviour {
	public const float interval = 5.0f;
	private float timeLeft = interval;
	public GameManager gm;
	public GameObject Batsu;
	public GameObject MushiMegane;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0)
		{
			timeLeft = interval;
			//ここに処理
			if(Random.Range(0, 2) == 0)
			{
				Instantiate(Batsu, new Vector3(Random.Range(gm.minPos, gm.maxPos), 0.05f, 42), Quaternion.identity);
			}
			else
			{
				Instantiate(MushiMegane, new Vector3(Random.Range(gm.minPos, gm.maxPos), 0.05f, 42), Quaternion.identity);
			}
		}
	}
}
