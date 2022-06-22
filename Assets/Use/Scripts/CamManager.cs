using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class CamManager : MonoBehaviour
{
    //�̵��ӵ� �����Ϸ��� ���� 
    public FirstPersonController controller;

    public Transform BasicTarget; //���� �ִ� ī�޶��� ��ġ
    public Transform Target;   // ������ �� ī�޶� ��ġ 

    private void Start()
    {
        transform.position = BasicTarget.position;
    }
    // Update is called once per frame
    void Update()
    {
        //�ٽ� ó�� ���� �ӵ��� �����·�
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("ALPHA1");
            controller.m_WalkSpeed = 4f;
            transform.position = BasicTarget.position;
        }

        //������ �� ī�޶� �̵�
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ALPHA2");
            controller.m_WalkSpeed = 1.5f;
            transform.position = Target.position;
        }
    }


}
