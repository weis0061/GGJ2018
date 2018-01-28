using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour {

    void OnMouseUpAsButton()
    {
        Debug.Log("unpause");
        GameState.Singleton.Unpause();
    }
    void Update()
    {
        Debug.Log("resume update");
        if (Input.GetKeyDown(KeyCode.Escape)) OnMouseUpAsButton();
    }
}
