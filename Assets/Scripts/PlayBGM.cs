using UnityEngine;
using System.Collections;

public class PlayBGM : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Use this for initialization

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = audioClip1;
        audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
