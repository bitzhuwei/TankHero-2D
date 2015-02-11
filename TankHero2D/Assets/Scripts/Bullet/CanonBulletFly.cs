using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CanonBulletFly : BulletFly
{
    public float damage;


    void Start()
    {
        //Debug.Log("CanonBulletFly.Start()");
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == Tags.coin) { return; }

        Destroy(this.gameObject);
    }


    public override float GetDamage(Transform gameObject)
    {
        return this.damage;
    }

    public override void Initiate(float velocity, string shooterTag, Vector3 targetPosition)
    {
        base.velocity = velocity;
        base.shooterTag = shooterTag;
        base.targetPosition = targetPosition;
    }
}
