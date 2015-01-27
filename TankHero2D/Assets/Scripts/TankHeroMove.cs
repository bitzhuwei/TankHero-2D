using UnityEngine;
using System.Collections;

public class TankHeroMove : MonoBehaviour {

	public float speed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");

		if (Mathf.Abs(h) > Quaternion.kEpsilon || Mathf.Abs(v) > Quaternion.kEpsilon)
		{
			Move (h, v);
		}
	}

	void Move(float h, float v) 
	{
		var moveVector = new Vector3 (h, v, 0);
		moveVector.Normalize ();
		this.transform.position += moveVector * speed * Time.deltaTime;
	}

}
