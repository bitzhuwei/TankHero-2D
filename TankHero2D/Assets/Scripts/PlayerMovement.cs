using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {

	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");
		
		if (Mathf.Abs(h) > Quaternion.kEpsilon || Mathf.Abs(v) > Quaternion.kEpsilon)
		{
			base.baseDirection = new Vector3 (h, v, 0).normalized;
			this.transform.position += base.baseDirection * base.speed * Time.deltaTime;
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;		
		if(Physics.Raycast(ray, out hit))
		{
			base.fireTarget = hit.point;
		}
		else
		{
			Debug.LogError(string.Format ("mouse click not hit anything! input: {0} mouse: {1} | {2}", 
			                              Input.mousePosition, "null", "null"));
		}
	}	
}