using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
	public Transform bulletStartPosition;

	public List<Transform> weapons;
    public bool userControlsFire;
	public bool autoFire;
	private int currentIndex;
	private Transform currentBullet;
	private WeaponConfig currentWeaponConfig;
	private Movement movementScript;
    private AudioSource shootAudioSource;
	private float passedInterval;
	void Awake()
	{
		movementScript = this.GetComponentInParent<Movement> ();
        this.shootAudioSource = this.audio;
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

        if (Time.deltaTime == 0) { return; }
		passedInterval += Time.deltaTime * 10;
		if (passedInterval >= currentWeaponConfig.interval)
		{
            if ((userControlsFire && Input.GetButton("Fire1")
                 || ((!userControlsFire) && this.autoFire)))
			{
				passedInterval = 0;
				var bullet = Instantiate(currentBullet, bulletStartPosition.position, this.transform.rotation) as Transform;
				bullet.renderer.enabled = true;
				var bulletFly = bullet.GetComponent<BulletFly>();
                bulletFly.Initiate(currentWeaponConfig, this.transform.parent.gameObject, movementScript);
                if (this.shootAudioSource != null)
                {
                    Debug.Log("shoot bullet.");
                    this.shootAudioSource.Play();
                }
                //if(this.audioSouce!=null)
                //{ this.audioSouce.Play(); }
			}
            
		}

	}

	public void SetWeapon(int index)
	{
		if (index < 0 || index >= this.weapons.Count) { return; }

		currentIndex = index;
		currentWeaponConfig = weapons[currentIndex].GetComponent<WeaponConfig>();
        this.shootAudioSource.clip = currentWeaponConfig.shootAudioClip;
		currentBullet = weapons [currentIndex].GetChild (0);
	}
}
