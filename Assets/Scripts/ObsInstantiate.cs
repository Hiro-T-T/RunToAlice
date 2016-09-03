using UnityEngine;
using System.Collections;

public class ObsInstantiate : MonoBehaviour
{
    public GameManager gm;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gm.timeLeft -= Time.deltaTime;
        if (gm.timeLeft <= 0.0)
        {
            gm.timeLeft = 3.0f;
            //ここに処理
            Instantiate(Resources.Load<GameObject>("Obstacle"), new Vector3(Random.Range(gm.minPos, gm.maxPos), 0, 42), Quaternion.identity);
        }
    }
}
