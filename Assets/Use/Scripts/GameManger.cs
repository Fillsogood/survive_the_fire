using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManger : MonoBehaviour
{

    private FirstPersonController controller;
    private CharacterController characterController;
    private bool gameOver = false;
    private bool gameClear = false;

    public GameObject player;

    void Start()
    {
        controller = player.GetComponent<FirstPersonController>();
        characterController = player.GetComponent<CharacterController>();
    }


    void Update()
    {
        if(controller.getHp() <= 0)
        {

        }
    }
}
