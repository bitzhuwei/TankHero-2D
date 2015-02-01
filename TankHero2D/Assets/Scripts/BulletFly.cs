using UnityEngine;
using System.Collections;

public abstract class BulletFly : MonoBehaviour {

    //public bool undying;
    public float velocity { get;set; }
    public string shooterTag { get;set; }
    public Vector3 targetPosition { get;set; }
    protected float passedTime;

	// Update is called once per frame
	protected void Update () {
		//Debug.Log ("BulletFly.Update()");
		//Debug.Log (this.transform.rotation.eulerAngles);
		var angle = this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
		var direction = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0);
		this.transform.position += direction * velocity * Time.deltaTime;
        passedTime += Time.deltaTime;
	}

    public abstract void Initiate(WeaponConfig weaponConfig, GameObject shooter, Movement movementScript);//,
//                                  bool enableRenderer = true, bool undying = false);

	public abstract float GetDamage (Transform gameObject);
}
