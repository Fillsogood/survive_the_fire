using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class CamManager : MonoBehaviour
{
    private CharacterController characterController;
    //이동속도 변경하려고 선언 
    public FirstPersonController controller;

    public Transform BasicTarget; //원래 있던 카메라의 위치
    public Transform Target;   // 숙였을 시 카메라 위치
    public GameObject player;

    private void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        transform.position = BasicTarget.position;
    }
    // Update is called once per frame
    void Update()
    {
        //스페이스바 눌렀을 시 숙임 
        if(Input.GetKey(KeyCode.Space))
        {
            controller.m_WalkSpeed = 2f;
            transform.position = Target.position;
            characterController.height = 1.4f;
        }
        //스페이바 땠을 시 다시 일어남 
        else
        {
            controller.m_WalkSpeed = 4f;
            transform.position = BasicTarget.position;
            characterController.height = 1.8f;
        }
        /*
        //다시 처음 시점 속도를 원상태로
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.m_WalkSpeed = 4f;
            transform.position = BasicTarget.position;
            characterController.height = 1.8f;

        }
        //숙였을 시 카메라 이동
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            controller.m_WalkSpeed = 2f;
            transform.position = Target.position;
            characterController.height = 1.4f;
        }
        */
    }


}
