using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	private Health healthScript;

	void Awake()
	{
		this.healthScript = this.GetComponentInChildren<Health> ();
	}

    void Start()
    {
    }


	void OnTriggerEnter2D(Collider2D other)
	{
		var bulletFlyScript = other.GetComponent<BulletFly> ();
        if (bulletFlyScript == null) { return; }

        /*
        if (bulletFlyScript.shooter == null)
        {
            Debug.Log(
                string.Format("{0}|{1} is hit by {2}|{3}",
                          this.name, this.tag, "<null> " + bulletFlyScript.name, "<null> " + bulletFlyScript.tag));
        }
        else
        {
            Debug.Log(string.Format("{0}|{1} is hit by {2}|{3}",
                          this.name, this.tag, bulletFlyScript.shooter.name, bulletFlyScript.shooter.tag));
        }
        */

        if (bulletFlyScript.shooterTag == this.tag) { return; }
        if (this.healthScript.health <= 0) { return; }

		var damage = bulletFlyScript.GetDamage(this.transform);
        this.healthScript.TakeDamage(damage);
    }
}
