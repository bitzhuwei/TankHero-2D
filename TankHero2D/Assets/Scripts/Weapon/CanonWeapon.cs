using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

sealed class CanonWeapon : Weapon
{
    public Transform bulletPrefab;
    public Transform bulletStartPosition;

    new void Awake()
    {
        base.Awake();
    }
    new void Update()
    {
        if (Time.deltaTime == 0) { return; }
        passedInterval += Time.deltaTime * 10;
        if (passedInterval >= base.shootInterval)
        {
            if ((userFires && Input.GetButton("Fire1"))
                 || ((!userFires)))
            {
                passedInterval = 0;
                var newBullet = Instantiate(bulletPrefab, bulletStartPosition.position, this.transform.rotation) as Transform;
                var bulletFly = newBullet.GetComponent<BulletFly>();
                bulletFly.Initiate(base.bulletVelocity, base.shooterTag, base.movementScript.fireTarget);
                this.shootAudioSource.Play();
            }

        }

    }
}
