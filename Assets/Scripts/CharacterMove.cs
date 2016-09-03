using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    public float moveSpeed = 0.1f;
    public float loadTime = 2.0f;
    public GameManager gm;

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
        this.transform.position = mousePointInWorld;
        //if (transform.position.x >= gm.maxPos)
        //{
        //    transform.position = new Vector3(gm.maxPos, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x <= gm.minPos)
        //{
        //    transform.position = new Vector3(gm.minPos, transform.position.y, transform.position.z);
        //}
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            gm.Invoke("GameOver", loadTime);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if(transform.position.x >= gm.maxPos)
        {
            transform.position = new Vector3(gm.maxPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= gm.minPos)
        {
            transform.position = new Vector3(gm.minPos, transform.position.y, transform.position.z);
        }
    }
}