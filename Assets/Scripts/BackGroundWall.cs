using UnityEngine;
using System.Collections;

public class BackGroundWall : MonoBehaviour {

    //public float scrollSpeed = 1f;

    public float textureSpeed = 1.0f;

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
        var x = Mathf.Repeat(Time.time * textureSpeed, 100);

        var offset = new Vector2(x, 0);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
