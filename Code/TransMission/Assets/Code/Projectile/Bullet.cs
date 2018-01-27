using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Displace))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public Vector2 velocity { get { return GetComponent<Displace>().Speed; } set { GetComponent<Displace>().Speed = value; } }
    void Start()
    {
        StartCoroutine(CheckIsOnCamera());
    }
    public IEnumerator CheckIsOnCamera()
    {
        while (true)
        {
            var vp = Camera.main.WorldToViewportPoint(transform.position);
            if (Mathf.Abs(vp.x) > 1.1 || Mathf.Abs(vp.y) > 1.1)
            {
                this.Destroy();
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
