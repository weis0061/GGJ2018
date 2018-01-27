using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Displace))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public Vector2 velocity { get { return GetComponent<Displace>().Speed; } set { GetComponent<Displace>().Speed = value; } }
}
