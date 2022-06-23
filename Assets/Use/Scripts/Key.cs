using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	private GameObject player;
	public GameObject key;
	public GameObject gm;
	private GM GM;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		GM = gm.GetComponent<GM>();
	}
	void Update()
	{
	
	}
    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)   
		{
			GM.GetKey();
			Destroy(key.gameObject);
		}
	}
}
