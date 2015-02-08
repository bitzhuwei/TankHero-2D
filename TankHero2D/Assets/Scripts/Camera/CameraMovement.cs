using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float catchingSpeed = 1;
    private GameObject tankHero;

	void Awake()
	{
		this.tankHero = GameObject.FindGameObjectWithTag (Tags.hero);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(string.Format("camera follows: {0}", this.tankHero));
        var target = this.tankHero;
        if (target == null) 
        {
            this.tankHero = GameObject.FindGameObjectWithTag(Tags.hero);
            target = this.tankHero;
        }
        if (target == null) { return; }

        var targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
		this.transform.position = Vector3.Lerp (this.transform.position, targetPosition, Time.deltaTime * this.catchingSpeed);
	}
}
