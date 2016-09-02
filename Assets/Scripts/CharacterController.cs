using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float moveSpeed = 0.1f;

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
    }
}