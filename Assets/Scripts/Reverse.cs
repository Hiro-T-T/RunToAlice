using UnityEngine;
using System.Collections;

public class Reverse : MonoBehaviour
{
    private const float effectTime = 5.0f;
    public float moveSpeed = 0.1f;

    private CharacterController cc; 

    // Use this for initialization
    void Start()
    {
        cc = GameObject.Find("alice").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, -moveSpeed);
    }

    public void FinishEffect()
    {
        cc.isReverse = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (cc != null)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                cc.isReverse = true;
                Invoke("FinishEffect", effectTime);
            }
            if (col.gameObject.CompareTag("End"))
            {
                Destroy(this.gameObject);
            }
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("End"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
