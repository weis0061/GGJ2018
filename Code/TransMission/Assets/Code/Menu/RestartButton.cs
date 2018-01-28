using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {
    void OnMouseUpAsButton()
    {
        GameState.Singleton.Respawn();
    }
}
