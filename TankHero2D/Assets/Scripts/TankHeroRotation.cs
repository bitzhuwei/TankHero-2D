using UnityEngine;
using System.Collections;

public class TankHeroRotation : MonoBehaviour {
	public float rotationSpeed = 10f;//degrees
	private float targetAngle;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");

		if (Mathf.Abs(h) > Quaternion.kEpsilon || Mathf.Abs(v) > Quaternion.kEpsilon)
		{
			this.targetAngle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
			//Debug.Log("target angle: " + targetAngle);
		}

		this.transform.rotation = Quaternion.Slerp (
			this.transform.rotation,
			Quaternion.Euler (0, 0, targetAngle),
		    rotationSpeed * Time.deltaTime);
	}
}
