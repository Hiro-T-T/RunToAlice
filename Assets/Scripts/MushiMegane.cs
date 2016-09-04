using UnityEngine;
using System.Collections;

public class MushiMegane : MonoBehaviour
{
    private const float effectTime = 5.0f;
    public float moveSpeed = 0.1f;
    GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, -moveSpeed);
    }

    public void FinishEffect()
    {
        gm.obsState = ObstacleState.Back;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gm.obsState = ObstacleState.Front;
            Invoke("FinishEffect", effectTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("end"))
        {
            Destroy(this.gameObject);
        }
    }
}
