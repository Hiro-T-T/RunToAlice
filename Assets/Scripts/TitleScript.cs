using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {
    
    public void OnClick()
    {
        SceneManager.LoadScene("mode");
    }
	
}
