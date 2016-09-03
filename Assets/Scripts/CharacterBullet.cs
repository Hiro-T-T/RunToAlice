using UnityEngine;
using System.Collections;

public class CharacterBullet : MonoBehaviour
{
    public float move;
    public float deleteTime;

    // Use this for initialization
    void Start()
    {
        Invoke("Delete", deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, move);
    }

    void OnMouseClick()
    {

    }

    void Delete()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
