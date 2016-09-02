using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private GameObject obstacle;
    public float ballSpeed = 0.3f;
    public float minPos = -4.0f;
    public float maxPos = 4.0f;
    public float timeLeft = 3.0f;
    public float textureSpeed = 2.0f;
     
    // Use this for initialization
    void Start () {
        obstacle = (GameObject)Resources.Load("Obstacle");
	}
	
	// Update is called once per frame
	void Update () {
        //timeLeft -= Time.deltaTime;
        //if (timeLeft <= 0.0)
        //{
        //    timeLeft = 3.0f;

        //    //ここに処理
        //    GameObject obs = Instantiate(obstacle, new Vector3(Random.Range(minPos, maxPos), 0, 42), Quaternion.identity)as GameObject;
        //    GameManager gm = obs.GetComponent<GameManager>();
        //    obs.
        //}
	}

    public void Create(GameManager gamemanager)
    {
        Instantiate(obstacle, new Vector3(Random.Range(minPos, maxPos), 0, 42), Quaternion.identity);
    }

    void GameOver()
    {
        SceneManager.LoadScene("result");
    }
}
