using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private GameObject obstacle;
    public float ballSpeed = 0.3f;
    public float minPos = -4.0f;
    public float maxPos = 4.0f;
    public float timeLeft = 3.0f;
    public static float textureSpeed = 2.0f;
    public float minRange = -4.0f;
    public float maxRange = 4.0f;
    public static int killCount;
    public float countTime = 30;
    public static bool coolTime = false;
    public static float intarval = 5.0f;
    public GameObject tex;

    //private static GameManager gm;
     
    // Use this for initialization
    void Start () {
        obstacle = (GameObject)Resources.Load("Obstacle");
 
        obstacle.GetComponent<ObstacleMove>().isBreakable = true;

        tex.GetComponent<Text>().text = ((int)countTime).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0)
        {
            timeLeft = 3.0f;

            //ここに処理
            Instantiate(obstacle, new Vector3(Random.Range(minPos, maxPos), 0, 42), Quaternion.identity);
        }

        countTime -= Time.deltaTime;
        if (countTime < 0)
        {
            countTime = 0;
            Invoke("GameOver", 2.0f);
        }
        tex.GetComponent<Text>().text = "残り時間" + ((int)countTime).ToString();
    }

    //public static GameManager GetInstance()
    //{
    //    return gm = gm ?? CreateInstance();
    //}

    //static GameManager CreateInstance()
    //{
    //    var prefab = Resources.LoadAll<GameManager>("")[0];
    //    var instance = GameObject.Instantiate<GameManager>(prefab);
    //    GameObject.DontDestroyOnLoad(instance);
    //    return instance;
    //}

    void GameOver()
    {
        SceneManager.LoadScene("result");
    }
}
