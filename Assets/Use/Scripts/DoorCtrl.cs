using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
	private GameObject player;
	private bool playerEntered;
	private int rayLayerMask;
	public GameObject p_Door;
	private Animator anim;
	public GameObject Key;
	public GameObject p_Key_Don;
	private AudioSource audio;
	public AudioClip open_Door;
	public AudioClip Close_Door;
	public GameObject gm;
	private GM GM;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		GM=gm.GetComponent<GM>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (Key.transform.childCount > 0)
        {
			p_Key_Don.SetActive(true);
		}
		if (other.gameObject == player&&Key.transform.childCount==0)     //player has collided with trigger
		{
			playerEntered = true;
			audio.PlayOneShot(open_Door);
			p_Door.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)     //player has exited trigger
		{
			playerEntered = false;
			audio.PlayOneShot(Close_Door);
			GM.BGM();
			p_Door.SetActive(false);
			p_Key_Don.SetActive(false);
		}
	}
	void Update()
	{
		if(playerEntered==true)
        {
			anim.SetBool("isOpen", true);
        }
		else if(playerEntered==false)
        {
			anim.SetBool("isOpen", false);
		}
        else { }
	}
}
