using UnityEngine;
using System.Collections;

public class TankHeadRotation : MonoBehaviour {

	public Transform rotationCenter;
	//public Vector3 targetPosition;
	public float rotationSpeed = 20f;//degrees
	private float targetAngle;

	void Awake()
	{
		//this.targetPosition = new Vector3 (1, 0, 0);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;		
		if(Physics.Raycast(ray, out hit))
		{
			var p = hit.point;
			Debug.DrawRay(Input.mousePosition, p, Color.red, 3, false);
			var y = p.y - this.transform.position.y;
			var x = p.x - this.transform.position.x;
			//var direction = this.targetPosition - this.transform.position;
			if (Mathf.Abs(y) > Quaternion.kEpsilon || Mathf.Abs(x) > Quaternion.kEpsilon)
			{
				this.targetAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
				//Debug.Log("target angle: " + targetAngle);
				var angle = this.targetAngle - this.transform.localRotation.eulerAngles.z;
				var maxAngle = rotationSpeed * Time.deltaTime * 50;
				//Debug.Log(string.Format("{0} vs {1}", angle, maxAngle));
				//if (angle > maxAngle && maxAngle > 0) { angle = maxAngle; }
				//else if (angle < -maxAngle && -maxAngle < 0) { angle = -maxAngle; }

				this.transform.RotateAround (this.rotationCenter.position, new Vector3 (0, 0, 1), angle);
			}
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
