using UnityEngine;
using System.Collections;

public class ObsInstantiate : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.GetInstance().timeLeft -= Time.deltaTime;
        if (GameManager.GetInstance().timeLeft <= 0.0)
        {
            GameManager.GetInstance().timeLeft = 3.0f;
            //ここに処理
            Instantiate(Resources.LoadAll<GameObject>("Obstacle")[0], new Vector3(Random.Range(GameManager.GetInstance().minPos, GameManager.GetInstance().maxPos), 0, 42), Quaternion.identity);
        }
    }
}
