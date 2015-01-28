using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour {

	public bool undying = false;
	public float velocity = 10;
	public GameObject shooter;
	public Vector3 targetPosition;

	// Update is called once per frame
	protected void Update () {
		//Debug.Log ("BulletFly.Update()");
		//Debug.Log (this.transform.rotation.eulerAngles);
		var angle = this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
		var direction = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0);
		this.transform.position += direction * velocity * Time.deltaTime;
	}
}
