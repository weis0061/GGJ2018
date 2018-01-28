using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject RespawnMenu;
    public GameObject PauseMenu;
    public static bool isGameActive=true;
    static bool gameStateAlreadyExists = false;

    static GameState _singleton;
    public static GameState Singleton
    {
        get
        {
            {
                if (_singleton == null) Debug.LogError("Not actually using singletons. Use this a bit more safely pls");
                return _singleton;
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        if (_singleton != null)
        {
            Destroy(gameObject);
            return;
        }
        _singleton = this;
        DontDestroyOnLoad(gameObject);
        RespawnMenu.SetActive(false);
        PauseMenu.SetActive(false);
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDroneDead)
        {
            DeathTimeLeft -= Time.deltaTime;
            if (DeathTimeLeft < 0)
            {
                isDroneDead = false;
                DeathTimeLeft = DeathTimer;
                RespawnMenu.SetActive(true);
                isGameActive = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    float DeathTimer = 3f;
    float DeathTimeLeft = 3f;
    bool isDroneDead = false;

    public void DroneDeath()
    {
        isDroneDead = true;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        isGameActive = false;
        AudioListener.volume = 0.5f;
    }
    public void Unpause()
    {
        PauseMenu.SetActive(false);
        RespawnMenu.SetActive(false);
        isGameActive = true;
        AudioListener.volume = 1f;
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Unpause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
