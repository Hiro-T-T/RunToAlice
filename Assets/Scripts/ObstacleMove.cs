using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour
{

    // 消せるかどうか　とりあえずGameManagerでtrueに変更してる
    public bool isBreakable = false;

    public float moveSpeed = 0.1f;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //void FixedUpdate()
    //{
    //    rb.AddForce(transform.forward * -moveSpeed);
    //}

    //Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("End"))
        {
            print("a");
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            print("b");
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            print("c" + this.GetComponent<Obstacle>().CardNum);
            CharacterController.hp -= this.GetComponent<Obstacle>().CardNum;
            if (CharacterController.hp < 0) CharacterController.hp = 0;

            if (CharacterController.hp <= 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
                //Destroy(this.gameObject);
            }


            Destroy(this.gameObject);
        }
    }
}