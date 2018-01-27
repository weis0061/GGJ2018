using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletPool
{
    const uint MAXBULLETS = 1200;
    static Bullet[] Pool = new Bullet[MAXBULLETS];
    public static void Destroy(this Bullet bullet)
    {
        Object.Destroy(bullet.gameObject);
        return;
        bullet.gameObject.SetActive(false);
        bullet.transform.parent = null;
        bullet.transform.position = Vector3.zero;
    }
}
public static class Extensions {
    public static Vector2 xy(this Vector3 xyz)
    {
        return new Vector2(xyz.x, xyz.y);
    }
}
