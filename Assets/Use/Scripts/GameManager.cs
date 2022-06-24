using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPannel;
    [SerializeField] GameObject GameClearPannel;
    [SerializeField] GameObject Monsters;
    [SerializeField] UIManager manager;

    public static int Monster_Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //재시작 위해서 초기화 
        Time.timeScale = 1;
        manager.controllerstop(true);
        PlayerCtrl.currentHealth = 100;
        Monster_Count = Monsters.transform.childCount;
        Debug.Log("총 몬스터의 수 " + Monster_Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCtrl.currentHealth <= 0)
        {
            manager.controllerstop(false);
            GameOverPannel.SetActive(true);
        }

        if (Monster_Count == 0)
        {
            Debug.Log(Monster_Count);
            manager.controllerstop(false);
            GameClearPannel.SetActive(true);
        }
    }
    public void Restart_Btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
