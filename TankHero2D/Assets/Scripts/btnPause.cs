using UnityEngine;
using System.Collections;

public class btnPause : MonoBehaviour {

    private float originalTimeScale;
    private UnityEngine.UI.Text buttonText;

    void Awake()
    {
        this.originalTimeScale = Time.timeScale;
        this.buttonText = this.GetComponentInChildren<UnityEngine.UI.Text>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            btnPause_Click();
        }
    }

    public void btnPause_Click()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            buttonText.text = "Continue";
        }
        else
        {
            Time.timeScale = this.originalTimeScale;
            buttonText.text = "Pause";
        }
    }
}
