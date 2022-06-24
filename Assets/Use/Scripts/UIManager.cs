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

    //만약 재시작 했을시 망가OFF, 게임 스타트 ON 해줘야함 
    public static bool isExitGameRestart = false;
    [SerializeField] GameObject manga;  //망가
    [SerializeField] GameObject GameStart;  //게임스타트

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
        //ESC 눌렀을 시 일시정지 관련
        if (Input.GetKeyUp(KeyCode.Escape) && GameStart.activeSelf == true)
        {
            //일시정지
            if (Setting_Canvas.activeSelf == false)
            {
                controllerstop(false);
                Setting_Canvas.SetActive(true);
                volumeSetting_Pannel.SetActive(false);
                Time.timeScale = 0;
            }
            //일시정지 해체 
            else
            {
                controllerstop(true);
                if (controller != null) controller.enabled = true;
                Setting_Canvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    //true -> 캐릭터 스크립트 ON, 마우스 안보이게, 마우스 다시 잠금 (일시정지 해체)
    //false -> 캐릭터 스크립트 OFF, 마우스 보이게, 마우스 잠금 해체 (일시정지)
    public void controllerstop(bool check)
    {
        if (controller != null) controller.enabled = check;
        Cursor.visible = !check;
        if (check) Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
    }


    //만약 게임 오브젝트가 활성화 되어있으면 Off, 활성화 되지 않았으면 On (범용적으로 쓰임)
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

    //string으로 입력받는 씬이동
    public void SceneChange(string name)
    {
        if(SceneManager.GetActiveScene().name== "ExitSchool")
        {
            Stage1Clear = true;
            Debug.Log("탈출 클리어" + Stage1Clear);
        }
        else if(SceneManager.GetActiveScene().name== "Home")
        {
            Stage2Clear = true;
            Debug.Log("홈씬 클리어" + Stage2Clear);
        }
        SceneManager.LoadScene(name);
    }
    //숫자로 입력받는 씬이동 
    public void SceneChange(int i)
    {
        SceneManager.LoadScene(i);
    }

    //씬 재시작 hp를 다시 100으로 늘려줌, 만화가 다시 안뜨게 변경, 컨트롤러가 다시 동작하게 변경 
    public void ReStartGame()
    {
        FirstPersonController.hp = 100;
        isExitGameRestart = true;
        controllerstop(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //manga.SetActive(false);
        //GameStart.SetActive(true);
    }

    //계속하기 
    public void Continue()
    {
        controllerstop(true);
        Time.timeScale = 1;
        Setting_Canvas.SetActive(false);
    }

    //게임 종료 
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
