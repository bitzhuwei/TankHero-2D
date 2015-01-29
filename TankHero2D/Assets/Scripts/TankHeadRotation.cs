using UnityEngine;
using System.Collections;

public class TankHeadRotation : MonoBehaviour {

	public Transform rotationCenter;
	//public Vector3 targetPosition;
	public float rotationSpeed = 20f;//degrees
	private float targetAngle;
	private Movement movementScript;

	void Awake()
	{
		this.movementScript = this.GetComponentInParent<Movement> ();
		//this.targetPosition = new Vector3 (1, 0, 0);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.rotation.eulerAngles != this.transform.localRotation.eulerAngles)
		{
			Debug.LogWarning(string.Format("Tank head's rotation: {0} vs {1}", this.transform.rotation.eulerAngles,
			                               this.transform.localRotation.eulerAngles));
		}

		if (this.movementScript == null) { return; }

		var y = this.movementScript.fireTarget.y - this.transform.position.y;
		var x = this.movementScript.fireTarget.x - this.transform.position.x;
		if (Mathf.Abs(y) > Quaternion.kEpsilon || Mathf.Abs(x) > Quaternion.kEpsilon)
		{
			this.targetAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			//Debug.Log("target angle: " + targetAngle);
			var angle = this.targetAngle - this.transform.rotation.eulerAngles.z; //this.transform.localRotation.eulerAngles.z;
			//var maxAngle = rotationSpeed * Time.deltaTime * 50;
			//Debug.Log(string.Format("{0} vs {1}", angle, maxAngle));
			//if (angle > maxAngle && maxAngle > 0) { angle = maxAngle; }
			//else if (angle < -maxAngle && -maxAngle < 0) { angle = -maxAngle; }
			
			this.transform.RotateAround (this.rotationCenter.position, new Vector3 (0, 0, 1), angle);
		}

		/*
	    this.transform.localRotation = Quaternion.Slerp (
			this.transform.rotation,
			Quaternion.Euler (0, 0, targetAngle),
			rotationSpeed * Time.deltaTime);
		this.transform.rotation = Quaternion.Slerp (
			this.transform.rotation,
			Quaternion.Euler (0, 0, targetAngle),
			rotationSpeed * Time.deltaTime);
			*/
	}
}
