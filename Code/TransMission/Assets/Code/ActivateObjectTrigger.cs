using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectTrigger : MonoBehaviour, ITrigger {
    public void Trigger()
    {
        gameObject.SetActive(true);
    }
}
