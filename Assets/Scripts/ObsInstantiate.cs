using UnityEngine;
using System.Collections;

public class ObsInstantiate : MonoBehaviour
{
    public GameManager gm;
    // Use this for initialization
    void Start()
    {
        gm = this.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gm.timeLeft -= Time.deltaTime;
        if (gm.timeLeft <= 0.0)
        {
            gm.timeLeft = 4.0f;
            //ここに処理
            GameObject obs = Resources.Load<GameObject>("Obstacle");
            obs.GetComponent<Obstacle>().CardNum = Random.Range(1, 14);
            obs.GetComponent<Obstacle>().State = gm.obsState;
            Instantiate(obs, new Vector3(Random.Range(gm.minPos, gm.maxPos), 1.6f, 42), obs.transform.rotation);
        }
    }
}
