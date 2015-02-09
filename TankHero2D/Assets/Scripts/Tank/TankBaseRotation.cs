using UnityEngine;
using System.Collections;

public class TankBaseRotation : MonoBehaviour {
	public float rotationSpeed = 10f;//degrees
	private float targetAngle;
	private Quaternion targetRotation;
	private Movement movementScript;

	void Awake()
	{
		this.movementScript = this.GetComponentInParent<Movement> ();
		this.targetRotation = Quaternion.Euler (0, 0, this.targetAngle);
		//Debug.Log ("hi: " + movementScript);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movementScript == null) { return; }

		var angle = Mathf.Atan2 (movementScript.baseDirection.y, movementScript.baseDirection.x) * Mathf.Rad2Deg;
		if (Mathf.Abs(angle - this.targetAngle) > 0.01f)
		{
			this.targetAngle = angle;
			this.targetRotation = Quaternion.Euler (0, 0, angle);
		}

		this.transform.rotation = Quaternion.Slerp (
			this.transform.rotation,
			this.targetRotation,
			rotationSpeed * Time.deltaTime);
	}
}
