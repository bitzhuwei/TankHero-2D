using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float fullHP = 100;
	public float HP = 100;
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
		if (this.HP <= 0) { return; }

		if (this.HP <= value)
		{ this.HP = 0f; }
		else
		{
			this.HP -= value;
			lastDamageTime = Time.time;
		}
	}

	public void FillHealth(float value)
	{
		if (this.HP >= this.fullHP) { return; }

        if (this.fullHP - this.HP <= value)
        { this.HP = this.fullHP; }
        else
        {
            this.HP += value;
            lastFillTime = Time.time;
        }
	}
}
