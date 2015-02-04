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
        if (this.healthScript.health <= 0) { return; }

		var bulletFlyScript = other.GetComponent<BulletFly> ();
        if (bulletFlyScript == null) { return; }
        if (bulletFlyScript.shooterTag == this.tag) { return; }

		var damage = bulletFlyScript.GetDamage(this.transform);
        this.healthScript.TakeDamage(damage);
    }
}
