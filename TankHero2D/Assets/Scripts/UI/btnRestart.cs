using UnityEngine;
using System.Collections;

public class btnRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnRestart_Click()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
