using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public float moveSpeed = 0.1f;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * -moveSpeed);
    }

	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0,0,-moveSpeed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("end"))
        {
            Destroy(this.gameObject);
        }
    }
}
