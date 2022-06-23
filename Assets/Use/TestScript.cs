using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class TestScript : MonoBehaviour
{
    [SerializeField] FirstPersonController controller;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(controller != null) controller.enabled = false;

            Debug.Log("ESC ����");
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            if (controller != null) controller.enabled = true;
            Debug.Log("�����̽��� ����");
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
