using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : Client
{
    private bool connectserver = true;
    public Toggle toggle;
    public int ClientNum = 0;
    private bool isFirstCall = true;
<<<<<<< HEAD
    [SerializeField]
    Graphic m_Graphics;
    [SerializeField]
    public float Angular = 1.0f;
    [SerializeField]
    public float DeltaTime_speed = 0.0333f;
    Coroutine m_Coroutine;
    public float moveSceneSec = 2.0f;
    public bool named = false;
    public NameManager namemam;
    public GameObject image_s;
    public GameObject texF;


=======
    
>>>>>>> 36d4dc1baa13f5d5ba9fc80bad3b89863d37a165
    public static TitleScript Instance
    {
        get; private set;
    }

    void Awake()
    {
        StartFlash();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        MessageReceived += ClientNumReceived;
    }

    public void OnClick()
    {
        if (connectserver == false)
        {
            MessageReceived -= ClientNumReceived;
            SceneManager.LoadScene("mode");
        }
        else
        {
            if (ConnectionStart())
            {
                if (isFirstCall)
                {
                    //StartCoroutine(StartReadLoop());
                    isFirstCall = false;
                }

                StartCoroutine(WaitForConnecting());
            }
            else
            {
                Debug.Log("サーバに接続できませんでした");
            }
        }
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
                SceneManager.LoadScene("mode");
                break;
            }
            else
            {
                Debug.Log("サーバに接続できませんでした ClientNum : " + ClientNum);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void isOn()
    {
        if (toggle != null)
        {
            connectserver = toggle.isOn;
            Debug.Log(connectserver);
        }
    }

    private void ClientNumReceived(string num)
    {
        print("numreceived" + num);
        ClientNum = int.Parse(num);
    }

    void Reset()
    {
        m_Graphics = GetComponent<Graphic>();
    }
    IEnumerator Flash()
    {
        float m_Time = 0.0f;
        while (true)
        {
            m_Time += Angular * DeltaTime_speed;
            var color = m_Graphics.color;
            color.a = Mathf.Abs(Mathf.Sin(m_Time));
            m_Graphics.color = color;
            yield return new WaitForSeconds(DeltaTime_speed);
            if (Input.anyKey && named == false)
            {
                Angular = 100f;

                Invoke("DelayMethod", moveSceneSec);

            }

        }
    }



    private void DelayMethod()
    {

        named = true;

    }

    public void StartFlash()
    {
        m_Coroutine = StartCoroutine(Flash());
    }

    public void StopFlash()
    {
        StopCoroutine(m_Coroutine);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (named == false && namemam.name_move == true)
        {


        }
        if (named)
        {
            image_s.gameObject.GetComponent<Image>().enabled = false;
            texF.SetActive(true);
        }
        else
        {
            image_s.gameObject.GetComponent<Image>().enabled = true;
            texF.SetActive(false);
        }
    }
}
