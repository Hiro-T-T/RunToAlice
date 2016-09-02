using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour
{
    //public float scrollSpeed = 1f;
    public GameObject gm;
    GameManager gamemanager;
    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
        gamemanager = gm.GetComponent<GameManager>();
    }

    void Update()
    {
        ScrollTexture();
    }

    void ScrollTexture()
    {
        var y = Mathf.Repeat(Time.time * gamemanager.textureSpeed, 100);

        var offset = new Vector2(0, -y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
