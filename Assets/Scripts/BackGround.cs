using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour
{
    //public float scrollSpeed = 1f;

    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
    }

    void Update()
    {
        ScrollTexture();
    }

    void ScrollTexture()
    {
        var y = Mathf.Repeat(Time.time * GameManager.GetInstance().textureSpeed, 100);

        var offset = new Vector2(0, -y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
