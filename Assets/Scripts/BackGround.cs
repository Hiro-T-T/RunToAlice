using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour
{
    
    private float scrollSpeed = 0.5f;

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
        var y = Mathf.Repeat(Time.time * scrollSpeed, 1);

        var offset = new Vector2(0, y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
