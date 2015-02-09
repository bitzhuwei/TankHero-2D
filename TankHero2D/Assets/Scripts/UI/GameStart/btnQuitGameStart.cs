using UnityEngine;
using System.Collections;

public class btnQuitGameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnQuit_Click()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
