using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    public float moveSpeed = 0.1f;
    public float loadTime = 2.0f;
    public static int hp;
    public int damageMin = 1;
    public int damageMax = 10;
    public GameManager gamemanager;
    public GameObject bullet;
    public GameObject tex;

    void Start()
    {
        if(ModeManager.gameMode == 1)
        {
            hp = 0;
        }

        if(ModeManager.gameMode == 2)
        {
            hp = 150;
        }
        
    }

    void Update()
    {
        if (ModeManager.gameMode == 1)
        {
            tex.GetComponent<Text>().text = "Point:" + ((int)hp).ToString();
        }

        if (ModeManager.gameMode == 2)
        {
            tex.GetComponent<Text>().text = "HP:" + ((int)hp).ToString();
        }
    }

    void OnMouseDown()
    {
        Instantiate(bullet, new Vector3(this.transform.position.x, 0.5f,1f), new Quaternion(1.0f, 0, 0, 1.0f));
    }

    void OnMouseDrag()
    {
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x - moveSpeed,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        mousePointInWorld.y = this.transform.position.y;
        mousePointInWorld.z = this.transform.position.z;
        mousePointInWorld.x = Mathf.Clamp(mousePointInWorld.x, -3, 3);
        this.transform.position = mousePointInWorld;
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            if (ModeManager.gameMode == 1)
            {
                hp += Random.Range(damageMin, damageMax);
                if(hp == 21)
                {
                    gamemanager.Invoke("GameOver", loadTime);
                }
            }

            if (ModeManager.gameMode == 2)
            {
                hp -= Random.Range(damageMin, damageMax);
                if (hp <= 0)
                {
                    gamemanager.Invoke("GameOver", loadTime);
                    //Destroy(this.gameObject);
                }
            }
        }
    }
}