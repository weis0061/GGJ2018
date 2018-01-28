using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    float speed = 0f;
    GameObject player;
    void Start()
    {
        player = FindObjectOfType<Drone>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameState.isGameActive)
        {
            transform.eulerAngles.Set(0, 0, Vector2.Angle(transform.position,player.transform.position));
        }
    }
}
