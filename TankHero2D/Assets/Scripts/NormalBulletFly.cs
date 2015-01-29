using UnityEngine;
using System.Collections;

public class NormalBulletFly : BulletFly {

	void Start()
	{
		Debug.Log ("NormalBulletFly.Start()");
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//Debug.Log (string.Format("NormalBulletFly.OnTriggerEnter2D({0})", collider.name));
		if (this.undying) { return; }


		Destroy (this.gameObject);
	}

	/* Update()事件，Unity只找那个离MonoBehaviour最近的Update()执行。
	void Update()
	{
		Debug.Log ("NormalBulletFly.Update()");
		base.Update ();
		//base.SendMessageUpwards ("Update", SendMessageOptions.DontRequireReceiver);
	}
	*/

}
