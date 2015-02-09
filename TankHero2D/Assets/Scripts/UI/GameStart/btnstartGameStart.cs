using UnityEngine;
using System.Collections;

public class btnstartGameStart : MonoBehaviour {

    public AudioClip clickSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void btnStart_Click()
    {
        if (clickSound != null)
        { AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position); }
        Application.LoadLevel(SceneNames.freeLevel);
    }
}
