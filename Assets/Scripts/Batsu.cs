using UnityEngine;
using System.Collections;

public class Batsu : MonoBehaviour
{

    private const float effectTime = 5.0f;
    public float moveSpeed = 0.1f;

    public GameObject instantiateImage;

    // Use this for initialization
    void Start()
    {
        instantiateImage = GameObject.Find("Attack");

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, -moveSpeed);
    }

    public void FinishEffect()
    {
        instantiateImage.SetActive(true);
    }


    void OnTriggerEnter(Collider col)
    {
        if (instantiateImage != null)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                instantiateImage.SetActive(false);
                Invoke("FinishEffect", effectTime);
            }
        }
        if (col.gameObject.CompareTag("End"))
        {
            Destroy(this.gameObject);
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
