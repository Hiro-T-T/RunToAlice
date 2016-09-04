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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("end"))
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }

    }
}