using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var gameController = GameController.instance;
        gameController.GetComponent<SendHero>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
