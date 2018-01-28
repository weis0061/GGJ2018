using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject RespawnMenu;
    public GameObject PauseMenu;
    public static bool isGameActive;
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
    }

    float DeathTimer = 5f;
    float DeathTimeLeft = 5f;
    bool isDroneDead = false;

    public void DroneDeath()
    {
        isDroneDead = true;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        isGameActive = false;
    }
    public void Unpause()
    {
        PauseMenu.SetActive(false);
        isGameActive = true;
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
