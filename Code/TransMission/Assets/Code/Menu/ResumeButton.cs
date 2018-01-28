using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour {

    void OnMouseDownAsButton()
    {
        GameState.Singleton.Unpause();
        Debug.Log("unpause");
    }
    void Update()
    {
        Debug.Log("resume update");
        if (Input.GetKeyDown(KeyCode.Escape)) OnMouseDownAsButton();
    }
}
