using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMane : MonoBehaviour
{

    public bool isBullet = true;
    public float interval = 3.0f;
    public float speed=5.0f;

    public GameObject bulletPrefab;

    private void Start()
    {
        StartCoroutine(Bullet_mane());
    }

    private IEnumerator Bullet_mane()
    {
        while(isBullet)
        {
            yield return new WaitForSeconds(interval);
            FireBullet();
        }
    }

    private void FireBullet()
    {
        Vector3 launchPos = this.transform.position;
        GameObject bullet = Instantiate(bulletPrefab, launchPos, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }
}
