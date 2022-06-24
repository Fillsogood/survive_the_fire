using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaManager : MonoBehaviour
{
    [SerializeField] GameObject GameStart;
    [SerializeField] Image manga_Image;
    [SerializeField] Sprite[] manga;

    public bool Ending;
    int cnt_manga = 1;
    int mangaCount;
    // Start is called before the first frame update
    void Start()
    {
        mangaCount = manga.Length - 1;
        Debug.Log(mangaCount);
    }

    
    public void ClickManga()
    {
        manga_Image.sprite = manga[cnt_manga];
        if(cnt_manga<mangaCount) cnt_manga++;
        else if(cnt_manga>=mangaCount && Ending)
        {
            Debug.Log("엔딩 발동");
            Application.Quit();
        }
        else 
        {
            gameObject.SetActive(false);
            GameStart.SetActive(true);
        }
    }
}
