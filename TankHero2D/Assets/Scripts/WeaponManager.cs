using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
	public Transform bulletStartPosition;

	public List<Transform> weapons;
	private int currentIndex;
	private Transform currentBullet;
	private WeaponConfig currentWeaponConfig;

	private float passedInterval;
	
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

		passedInterval += Time.deltaTime * 10;
		if (passedInterval >= currentWeaponConfig.interval)
		{
			if (Input.GetButton("Fire1"))
			{
				passedInterval = 0;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;		
				if(Physics.Raycast(ray, out hit))
				{
					var bullet = Instantiate(currentBullet, bulletStartPosition.position, this.transform.rotation) as Transform;
					bullet.renderer.enabled = true;
					var bulletFly = bullet.GetComponent<BulletFly>();
					bulletFly.undying = false;
					bulletFly.velocity = currentWeaponConfig.velocity;
					bulletFly.shooter = this.gameObject;
					bulletFly.targetPosition = hit.point;
					//Destroy(bullet.gameObject, 5f);
				}
				else
				{
					Debug.LogError(string.Format ("mouse click not hit anything! input: {0} mouse: {1} | {2}", 
					                              Input.mousePosition, "null", "null"));
				}
			}
		}
	}
	
	public void SetWeapon(int index)
	{
		if (index < 0 || index >= this.weapons.Count) { return; }

		currentIndex = index;
		currentWeaponConfig = weapons[currentIndex].GetComponent<WeaponConfig>();
		currentBullet = weapons [currentIndex].FindChild ("Bullet");
	}
}
