﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    public float moveSpeed = 0.1f;
    public float loadTime = 2.0f;
    public GameManager gamemanager;
    public GameObject bullet;

    void OnMouseDown()
    {
        Instantiate(bullet, this.transform.position, new Quaternion(1.0f, 0, 0, 1.0f));
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
            gamemanager.Invoke("GameOver", loadTime);
            Destroy(this.gameObject);
        }
    }
}