using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
	public Transform bulletStartPosition;

	public List<Transform> weapons;
	public bool autoFire;
	private int currentIndex;
	private Transform currentBullet;
	private WeaponConfig currentWeaponConfig;
	private Movement movementScript;
	private float passedInterval;

	void Awake()
	{
		movementScript = this.GetComponentInParent<Movement> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (weapons == null || weapons.Count < 1) { return; }
		if (currentBullet == null)
		{
			SetWeapon(0);
		}
		if (currentBullet == null) { return; }
		if (movementScript == null) { return; }

		passedInterval += Time.deltaTime * 10;
		if (passedInterval >= currentWeaponConfig.interval)
		{
			if (this.autoFire || Input.GetButton("Fire1"))
			{
				passedInterval = 0;
				var bullet = Instantiate(currentBullet, bulletStartPosition.position, this.transform.rotation) as Transform;
				bullet.renderer.enabled = true;
				var bulletFly = bullet.GetComponent<BulletFly>();
				bulletFly.undying = false;
				bulletFly.velocity = currentWeaponConfig.velocity;
				bulletFly.shooter = this.gameObject;
				bulletFly.targetPosition = movementScript.fireTarget;
			}
		}
	}
	
	public void SetWeapon(int index)
	{
		if (index < 0 || index >= this.weapons.Count) { return; }

		currentIndex = index;
		currentWeaponConfig = weapons[currentIndex].GetComponent<WeaponConfig>();
		currentBullet = weapons [currentIndex].GetChild (0);
	}
}
