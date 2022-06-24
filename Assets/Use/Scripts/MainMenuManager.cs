using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject HideImage_Exit;
    public GameObject HideImage_Home;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);

        Debug.Log(UIManager.Stage1Clear);
        Debug.Log(UIManager.Stage2Clear);

        if(UIManager.Stage1Clear)
        {
            HideImage_Exit.SetActive(true);
        }
        else if(UIManager.Stage2Clear)
        {
            HideImage_Home.SetActive(true);
        }

        if (UIManager.Stage1Clear && UIManager.Stage2Clear)
        {
            SceneManager.LoadScene("AllClearScene");
        }
       
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
