using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyScript : MonoBehaviour
{
    public GameObject Ready;
    public GameObject Go;

    // Use this for initialization
    void Start()
    {
        Ready.SetActive(true);
        Go.SetActive(false);

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1000);
        Go.SetActive(true);
        yield return new WaitForSeconds(1000);

        SceneManager.LoadScene("game1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
