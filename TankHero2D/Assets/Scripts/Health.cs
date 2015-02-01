using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth = 100;
	public float health = 100;
	public float lastDamageTime;
	public float lastFillTime;

	void Awake()
	{
		this.lastDamageTime = -ShowHealthBar.interval;
		this.lastFillTime = -ShowHealthBar.interval;
	}

    
    void Start()
    {
    }

	public void TakeDamage(float value)
	{
		if (this.health <= 0) { return; }

		if (this.health <= value)
		{ this.health = 0f; }
		else
		{
			this.health -= value;
			lastDamageTime = Time.time;
		}
	}

	public void FillHealth(float value)
	{
		if (this.health >= this.maxHealth) { return; }

        if (this.maxHealth - this.health <= value)
        { this.health = this.maxHealth; }
        else
        {
            this.health += value;
            lastFillTime = Time.time;
        }
	}
}
