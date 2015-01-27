using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float catchingSpeed = 1;
	private Transform tankHero;

	void Awake()
	{
		this.tankHero = GameObject.FindGameObjectWithTag (Tags.hero).transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var targetPosition = new Vector3 (this.tankHero.position.x, this.tankHero.position.y, this.transform.position.z);
		this.transform.position = Vector3.Lerp (this.transform.position, targetPosition, Time.deltaTime * this.catchingSpeed);
	}
}
