using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private TitleScript ts;
    public GameObject ConnectingText;
    public GameObject CompleteText;

    // Use this for initialization
    void Start()
    {
        ts = TitleScript.Instance;

        ConnectingText.SetActive(true);
        CompleteText.SetActive(false);

        StartCoroutine(WaitForConnecting());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator WaitForConnecting()
    {
        while (true)
        {
            // クライアント数をサーバにリクエスト
            ts.RequestClientNum();
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ts.StartReading());

            if (ts.ClientNum >= 2)
            {
                ConnectingText.SetActive(false);
                CompleteText.SetActive(true);

                yield return new WaitForSeconds(1f);

                SceneManager.LoadScene("ready");
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void LoadReadyScene()
    {
        SceneManager.LoadScene("ready");
    }
}
