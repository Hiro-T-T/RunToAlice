using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryExitManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressRetry()
    {
        DestroyObject(TitleScript.Instance);
        SceneManager.LoadScene("title");
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
