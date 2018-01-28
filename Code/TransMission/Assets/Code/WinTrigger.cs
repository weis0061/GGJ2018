using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour,ITrigger {
    public GUITexture _guiTexture;
    bool didWin = false;
    public void Trigger()
    {
        didWin = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (didWin) _guiTexture.color = new Color(_guiTexture.color.r, _guiTexture.color.g, _guiTexture.color.b, _guiTexture.color.a + Time.deltaTime /8f);
        if (_guiTexture.color.a > 1f) SceneManager.LoadScene(2);
	}
}
