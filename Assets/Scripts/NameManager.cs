using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameManager : MonoBehaviour
{
    public TitleScript titleS;
    public bool name_move = false;
    string str;
    public InputField inputField;
    public Text text;
    public static string name_save;

    public static string NAME_KEY = "NameSave";
    //public string names;

    // Use this for initialization
    void Start()
    {
        //this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public static string getName()
    {
        return name_save;
    }

    public void SaveText()
    {
        str = inputField.text;
        text.text = str;
        inputField.text = "" + str;
        SaveHighScore();
        name_save = str;
        SceneManager.LoadScene("loading");
    }


    void SaveHighScore()
    {
        PlayerPrefs.SetString(NAME_KEY, str);
        PlayerPrefs.Save();
    }

    int LoadHighScore()
    {
        return PlayerPrefs.GetInt(NAME_KEY, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (titleS.named == true)
        {
            //this.gameObject.GetComponent<Canvas>().enabled = true;
            //Debug.Log(inputField.text);
            //names = inputField.text;
            //name_move = true;
        }

    }
}