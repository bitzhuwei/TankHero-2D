using UnityEngine;
using System.Collections;

public class btnokOfStore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnOK_Click()
    {
        Application.LoadLevel(SceneNames.freeLevel);
    }
}
