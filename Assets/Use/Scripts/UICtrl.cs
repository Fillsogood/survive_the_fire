using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
	private GameObject player;
	private bool playerEntered;
	private int rayLayerMask;
	public GameObject p_Fire_Extinguisher;
	public GameObject sHW_Fire_extinguisher_01_01;
	public GameObject gun;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
    void Update()
    {
      //  if(monster.)
    }
    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player&& gun.activeSelf == false)     //player has collided with trigger
		{
			playerEntered = true;
			p_Fire_Extinguisher.SetActive(true);
			Destroy(sHW_Fire_extinguisher_01_01);
			gun.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)     //player has exited trigger
		{
			playerEntered = false;
			p_Fire_Extinguisher.SetActive(false);
		}
	}

}
