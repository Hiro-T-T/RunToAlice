using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    private TitleScript ts;
    public GameObject ConnectingText;
    public GameObject CompleteText;

    // Use this for initialization
    void Start()
    {
        ts = TitleScript.Instance;

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
            RequestClientNum();
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(StartReading());

            if (ClientNum >= 1)
            {
                MessageReceived -= ClientNumReceived;
                isEntry = true;
                SceneManager.LoadScene("loading");
                break;
            }
            else
            {
                Debug.Log("サーバに接続できませんでした ClientNum : " + ClientNum);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
