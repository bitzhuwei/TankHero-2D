using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelMovement : MonoBehaviour {

	public float interval = 10;
	public List<GameObject> wheels;
	private int current = 0;
	private float passedInterval = 0;
    private int heroSpeed = 3;

	// Use this for initialization
	void Start () {
        heroSpeed = GameController.instance.heroConfig.fullSpeed;
		if (wheels != null && wheels.Count > 0)
		{ wheels[0].renderer.enabled = true; }

		for (int i = 1; i < wheels.Count; i++) 
		{
			wheels[i].renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (wheels == null || wheels.Count < 2) { return; }

		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");
		
		if (Mathf.Abs(h) > Quaternion.kEpsilon || Mathf.Abs(v) > Quaternion.kEpsilon)
		{
			passedInterval += Time.deltaTime * 20 * heroSpeed;
			//Debug.Log (passedInterval);
			if (passedInterval >= interval)
			{
				var tmp = current;

				if (current == wheels.Count - 1) { current = 0; }
				else { current++; }

				wheels[current].renderer.enabled = true;
				wheels[tmp].renderer.enabled = false;
				//Debug.Log(wheels[current].renderer);
				passedInterval = 0;
			}
		}
	}
}
