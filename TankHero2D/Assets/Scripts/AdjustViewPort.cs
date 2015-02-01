using UnityEngine;
using System.Collections;

public class AdjustViewPort : MonoBehaviour {

    public Texture borderTexture;
    Camera cameraComponent;
    private float screenWidth;
    private float screenHeight;
    private Rect originalCameraRect;

    void Awake()
    {
        this.cameraComponent = this.GetComponent<Camera>();
        this.originalCameraRect = this.cameraComponent.rect;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var width = Screen.width;
        var height = Screen.height;
        if (width == this.screenWidth && height == this.screenHeight) { return; }

        this.screenWidth = width;
        this.screenHeight = height;

        if (width > height)
        {
            var rect = this.cameraComponent.rect;
            rect.width = this.originalCameraRect.width * ((float)height / (float)width);
            this.cameraComponent.rect = rect;
        }
        else
        {
            var rect = this.cameraComponent.rect;
            rect.height = this.originalCameraRect.height * ((float)width / (float)height);
            this.cameraComponent.rect = rect;
        }
	}

    void OnGUI()
    {
        var rect = this.cameraComponent.rect;
        float left = 0;//Screen.width * rect.width;
        //Input.mousePosition.x - CurosrTexture.width / 2;
        float top = Screen.height - Screen.height * rect.height;
        float width = Screen.width * rect.width;
        float height = Screen.height * rect.height;
        
        GUI.DrawTexture(new Rect(left, top, width, height), this.borderTexture, ScaleMode.StretchToFill);
    }
}
