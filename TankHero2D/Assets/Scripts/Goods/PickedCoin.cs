using UnityEngine;
using System.Collections;

public class PickedCoin : MonoBehaviour {

    public AudioClip pickedAudioClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != Tags.hero) { return; }

        AudioSource.PlayClipAtPoint(pickedAudioClip, this.transform.position, 0.2f);
        MonoBehaviour.Destroy(this.gameObject);
    }
}
