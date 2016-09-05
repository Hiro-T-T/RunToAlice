using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyScript : MonoBehaviour
{
    public GameObject Ready;
    public GameObject Go;
    public static bool gameStart = false;

    // Use this for initialization
    void Start()
    {
        Debug.Log("ready");

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        
        yield return new WaitForSeconds(1);
        Debug.Log("OK");
        Ready.SetActive(true);
        Go.SetActive(false);
        Go.SetActive(true);
        Ready.SetActive(false);
        yield return new WaitForSeconds(1);
        Go.SetActive(true);
        Ready.SetActive(false);
        gameStart = true;
        yield return new WaitForSeconds(1);
        Destroy(Go.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
