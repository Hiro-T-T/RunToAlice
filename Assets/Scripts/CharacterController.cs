using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{

    public float moveSpeed = 0.1f;
    public float loadTime = 2.0f;
    public static int hp;
    public int damageMin = 1;
    public int damageMax = 10;
    public GameManager gamemanager;
    public GameObject bullet;
    public GameObject tex;
    // 操作反転
    public bool isReverse = false;

    void Start()
    {
        hp = 30;
    }

    void Update()
    {
        tex.GetComponent<Text>().text = "HP:" + ((int)hp).ToString();
    }

    //void OnMouseDown()
    //{
    //    Instantiate(bullet, new Vector3(this.transform.position.x, 0.5f, 1f), new Quaternion(1.0f, 0, 0, 1.0f));
    //}

    void OnMouseDrag()
    {
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x - moveSpeed,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        if (isReverse == false)
        {
            mousePointInWorld.y = this.transform.position.y;
            mousePointInWorld.z = this.transform.position.z;
            mousePointInWorld.x = Mathf.Clamp(mousePointInWorld.x, -2.5f, 2.5f);
        }
        else
        {
            mousePointInWorld.y = this.transform.position.y;
            mousePointInWorld.z = this.transform.position.z;
            mousePointInWorld.x = -1 * Mathf.Clamp(mousePointInWorld.x, -2.5f, 2.5f);
        }
        this.transform.position = mousePointInWorld;
    }

    void OnCollisionEnter(Collision col)
    {
        //if (col.gameObject.CompareTag("Enemy"))
        //{
        //    hp -= col.gameObject.GetComponent<Obstacle>().CardNum;

        //    if (hp <= 0)
        //    {
        //        gamemanager.Invoke("GameOver", 2.0f);
        //        //Destroy(this.gameObject);
        //    }

        //}
    }
}