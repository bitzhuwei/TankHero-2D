using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawMouseInfo : MonoBehaviour {

	Text guiText;

	void Awake()
	{
		guiText = this.GetComponent<Text> ();
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
			guiText.text = string.Format ("input: {0} mouse: {1} | {2}", 
			                              Input.mousePosition, hit.point, hit.transform.gameObject.name);
		}
		else
		{
			guiText.text = string.Format ("input: {0} mouse: {1} | {2}", 
			                              Input.mousePosition, "null", "null");
		}
	}
}
