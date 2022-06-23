using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class CamManager : MonoBehaviour
{
    private CharacterController characterController;
    //�̵��ӵ� �����Ϸ��� ���� 
    public FirstPersonController controller;

    public Transform BasicTarget; //���� �ִ� ī�޶��� ��ġ
    public Transform Target;   // ������ �� ī�޶� ��ġ
    public GameObject player;

    private void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        transform.position = BasicTarget.position;
    }
    // Update is called once per frame
    void Update()
    {
        //�ٽ� ó�� ���� �ӵ��� �����·�
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.m_WalkSpeed = 4f;
            transform.position = BasicTarget.position;
            characterController.height = 1.8f;

        }

        //������ �� ī�޶� �̵�
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            controller.m_WalkSpeed = 1.5f;
            transform.position = Target.position;
            characterController.height = 1.1f;
        }
    }


}
