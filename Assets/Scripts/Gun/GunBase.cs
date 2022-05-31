using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public float shotCooldown = 10.55f;
    public float nextShot = 0.0f;

    public Transform positionToShoot;

    public  Transform sideReference;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time > nextShot)
        {
            Shoot();
            nextShot = shotCooldown + Time.time;
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = sideReference.transform.localScale.x;
    }
}
