using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    private int acount;
    public GameObject p_Key;
    private AudioSource audio;
    public AudioClip BGM2;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    public void GetKey()
    {
        p_Key.SetActive(true);

        StartCoroutine(SetKey());
    }
    IEnumerator SetKey()
    {
        yield return new WaitForSeconds(1.0f);
        p_Key.SetActive(false);
    }
    public void BGM()
    {
        audio.clip = BGM2;
        audio.Play();
        
    }
}
