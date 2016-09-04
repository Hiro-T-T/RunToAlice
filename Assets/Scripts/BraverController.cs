using UnityEngine;
using System.Collections;

public class BraverController : MonoBehaviour {
    public GameObject braveBullet;
    public int bulletCount = 7;
    public float timeLeft = 3.0f;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0)
        {
            timeLeft = 3.0f;
            //ここに処理
            Instantiate(Resources.Load("shine"));
            bulletCount--;
            if(bulletCount <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            GameManager.killCount++;
            Destroy(this.gameObject);
        }
    }
}
