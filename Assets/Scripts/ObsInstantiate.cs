using UnityEngine;
using System.Collections;

public class ObsInstantiate : MonoBehaviour
{
    public GameManager gm;
    public float Interval = 4.0f;
    private float timeLeft;

    // Use this for initialization
    void Start()
    {
        timeLeft = Interval;
        gm = this.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0)
        {
            timeLeft = Interval;
            //ここに処理
            GameObject obs = Resources.Load<GameObject>("Obstacle");
            obs.GetComponent<Obstacle>().CardNum = Random.Range(1, 14);
            obs.GetComponent<Obstacle>().State = gm.obsState;
            Instantiate(obs, new Vector3(Random.Range(gm.minPos, gm.maxPos), 1.6f, 42), obs.transform.rotation);
        }
    }
}
