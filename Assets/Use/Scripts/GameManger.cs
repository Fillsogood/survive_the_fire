using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManger : MonoBehaviour
{

    private FirstPersonController controller;
    private CharacterController characterController;
    private bool gameOver = false;
    private bool gameClear = false;
    private AudioSource m_AudioSource;

    public GameObject player;
    public GameObject gameClearObject;
    public GameObject gameOverObject;
    public AudioClip gameClearSound;
    public AudioClip gameOverSound;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        controller = player.GetComponent<FirstPersonController>();
        characterController = player.GetComponent<CharacterController>();
    }


    void Update()
    {
        if(!(gameOver || gameClear))
        {
            if (controller.getHp() <= 0)
            {
                gameOver = true;
                GameOver();
            }

            if (controller.getGameClear())
            {
                gameClear = true;
                GameClear();
            }
        }
    }

    private void disableCharacterContent()
    {
        controller.enabled = false;
        characterController.enabled = false;
        Invoke("DisableScript", 0.5f);
    }

    private void GameOver()
    {
        disableCharacterContent();
        gameOverObject.SetActive(true);
        m_AudioSource.PlayOneShot(gameOverSound);
    }

    private void GameClear()
    {
        disableCharacterContent();
        gameClearObject.SetActive(true);
        m_AudioSource.PlayOneShot(gameClearSound);
    }

    private void DisableScript()
    {
        controller.enabled = false;
    }
}
