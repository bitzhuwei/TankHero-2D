using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushBackToField : MonoBehaviour {
	Dictionary<Collider, Vector3> initialPositionDict;// = new Dictionary<Collider, Vector3>();

	void Awake()
	{
		initialPositionDict = new Dictionary<Collider, Vector3> ();
	}

	void Update()
	{
		//Debug.Log (string.Format ("dict: {0}", initialPositionDict.Count));
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (string.Format("{0} triggered enter", other.gameObject.name));
		if (initialPositionDict.ContainsKey(other))
		{
			initialPositionDict[other] = other.transform.position;
		}
		else
		{
			initialPositionDict.Add(other, other.transform.position);
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		Push (other);
	}
	
	void OnTriggerExit(Collider other)
	{
		if (initialPositionDict.ContainsKey(other))
		{
			//Debug.Log (string.Format("{0} triggered exit", other.gameObject.name));
			initialPositionDict.Remove(other);
		}
	}
	
	void Push(Collider other)
	{
		Vector3 initialPosition = Vector3.zero;
		if (initialPositionDict.ContainsKey(other))
		{
			initialPosition = initialPositionDict[other];
		}
		else
		{
			Debug.LogError(string.Format("{0} should have been added to the dict.", other.gameObject.name));
		}
		
		if ((initialPosition - other.transform.position).magnitude > 0.001f)
		{
			//Debug.Log("lerp push");
			other.transform.position = Vector3.Lerp(other.transform.position, Vector3.zero, Time.deltaTime);
		}
		else
		{
			//Debug.Log("sudden push");
			other.transform.position = initialPosition;
		}
	}
}
