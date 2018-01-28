using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float speed = 3f;
    public float MaxSpeed = 60f;
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
            var AngleTo = AngleBetweenVector2(player.transform.position.xy(), transform.position.xy());
            Debug.Log(AngleTo);
            var AngleToClamped = Mathf.Clamp(AngleTo, transform.eulerAngles.z - MaxSpeed * Time.deltaTime, transform.eulerAngles.z + MaxSpeed * Time.deltaTime);
            transform.eulerAngles=new Vector3(0,0, AngleToClamped);
        }
    }
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
