using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class CamManager : MonoBehaviour
{
    //이동속도 변경하려고 선언 
    public FirstPersonController controller;

    public Transform BasicTarget; //원래 있던 카메라의 위치
    public Transform Target;   // 숙였을 시 카메라 위치 

    private void Start()
    {
        transform.position = BasicTarget.position;
    }
    // Update is called once per frame
    void Update()
    {
        //다시 처음 시점 속도를 원상태로
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("ALPHA1");
            controller.m_WalkSpeed = 4f;
            transform.position = BasicTarget.position;
        }

        //숙였을 시 카메라 이동
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ALPHA2");
            controller.m_WalkSpeed = 1.5f;
            transform.position = Target.position;
        }
    }


}
