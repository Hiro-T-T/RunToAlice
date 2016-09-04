using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private GameObject obstacle;
    public float ballSpeed = 0.3f;
    public float minPos = -4.0f;
    public float maxPos = 4.0f;
    public float timeLeft = 4.0f;
    public static float textureSpeed = 2.4f;
    public float minRange = -4.0f;
    public float maxRange = 4.0f;
    public static int killCount;
    public float countTime = 30;
    public static bool coolTime = false;
    public static float intarval = 2.0f;
    public int hp_middle = 70;
    public int hp_low = 30;
    public int hp_death = 10;
    public GameObject tex;
    public ObstacleState obsState = ObstacleState.Back;

    //private static GameManager gm;
     
    // Use this for initialization
    void Start () {
        obstacle = (GameObject)Resources.Load("Obstacle");
 
        //obstacle.GetComponent<ObstacleMove>().isBreakable = true;

        tex.GetComponent<Text>().text = ((int)countTime).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0)
        {
            timeLeft = 5.0f;

            //ここに処理
            //Insta();

        }

        countTime -= Time.deltaTime;
        if (countTime < 0)
        {
            countTime = 0;
            Invoke("GameOver", 2.0f);
        }
        tex.GetComponent<Text>().text = "残り時間" + ((int)countTime).ToString();

        // countTimeの変動
        if(CharacterController.hp < hp_middle)
        {
            intarval = 4.0f;
        }
        if (CharacterController.hp < hp_low)
        {
            intarval = 2.7f;
        }
        if (CharacterController.hp < hp_death)
        {
            intarval = 1.3f;
        }
    }

    public void Insta()
    {
        Instantiate(obstacle, new Vector3(Random.Range(minPos, maxPos), 0, 42), Quaternion.identity);
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
