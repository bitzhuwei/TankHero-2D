using UnityEngine;
using System.Collections;

public class txtMoneyUpdate : MonoBehaviour {

    private UnityEngine.UI.Text textBox;

    void Awake()
    {
        textBox = this.GetComponent<UnityEngine.UI.Text>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var heroConfig = GameController.instance.heroConfig;
        textBox.text = string.Format("{0}", heroConfig.money);
	}
}
