using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static bool Stage1Clear;
    public static bool Stage2Clear;

    [SerializeField] GameObject Setting_Canvas;
    [SerializeField] GameObject volumeSetting_Pannel;
    [SerializeField] FirstPersonController controller;

    //���� ����� ������ ����OFF, ���� ��ŸƮ ON ������� 
    public static bool isExitGameRestart = false;
    [SerializeField] GameObject manga;  //����
    [SerializeField] GameObject GameStart;  //���ӽ�ŸƮ

    private void Awake()
    {
        if (isExitGameRestart == true && SceneManager.GetActiveScene().name == "ExitSchool")
        {
            manga.SetActive(false);
            GameStart.SetActive(true);
        }
    }
    private void Update()
    {
        //ESC ������ �� �Ͻ����� ����
        if (Input.GetKeyUp(KeyCode.Escape) && GameStart.activeSelf == true)
        {
            //�Ͻ�����
            if (Setting_Canvas.activeSelf == false)
            {
                controllerstop(false);
                Setting_Canvas.SetActive(true);
                volumeSetting_Pannel.SetActive(false);
                Time.timeScale = 0;
            }
            //�Ͻ����� ��ü 
            else
            {
                controllerstop(true);
                if (controller != null) controller.enabled = true;
                Setting_Canvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    //true -> ĳ���� ��ũ��Ʈ ON, ���콺 �Ⱥ��̰�, ���콺 �ٽ� ��� (�Ͻ����� ��ü)
    //false -> ĳ���� ��ũ��Ʈ OFF, ���콺 ���̰�, ���콺 ��� ��ü (�Ͻ�����)
    public void controllerstop(bool check)
    {
        if (controller != null) controller.enabled = check;
        Cursor.visible = !check;
        if (check) Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
    }


    //���� ���� ������Ʈ�� Ȱ��ȭ �Ǿ������� Off, Ȱ��ȭ ���� �ʾ����� On (���������� ����)
    public void On_Off(GameObject gameObject)
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    //string���� �Է¹޴� ���̵�
    public void SceneChange(string name)
    {
        if(SceneManager.GetActiveScene().name== "ExitSchool")
        {
            Stage1Clear = true;
            Debug.Log("Ż�� Ŭ����" + Stage1Clear);
        }
        else if(SceneManager.GetActiveScene().name== "Home")
        {
            Stage2Clear = true;
            Debug.Log("Ȩ�� Ŭ����" + Stage2Clear);
        }
        SceneManager.LoadScene(name);
    }
    //���ڷ� �Է¹޴� ���̵� 
    public void SceneChange(int i)
    {
        SceneManager.LoadScene(i);
    }

    //�� ����� hp�� �ٽ� 100���� �÷���, ��ȭ�� �ٽ� �ȶ߰� ����, ��Ʈ�ѷ��� �ٽ� �����ϰ� ���� 
    public void ReStartGame()
    {
        FirstPersonController.hp = 100;
        isExitGameRestart = true;
        controllerstop(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //manga.SetActive(false);
        //GameStart.SetActive(true);
    }

    //����ϱ� 
    public void Continue()
    {
        controllerstop(true);
        Time.timeScale = 1;
        Setting_Canvas.SetActive(false);
    }

    //���� ���� 
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
