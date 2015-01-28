using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {
	//The texture that's going to replace the current cursor  
	public Texture2D cursorTexture;  
	
	//This variable flags whether the custom cursor is active or not  
	public bool ccEnabled = false;  
	
	void Start()  
	{  
		if (cursorTexture != null)
		{
			SetCustomCursor();
			//Call the 'SetCustomCursor' (see below) with a delay of 2 seconds.   
			//Invoke("SetCustomCursor",2.0f);  
		}  
	}
	
	void OnDisable()   
	{  
		//Resets the cursor to the default  
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);  
		//Set the _ccEnabled variable to false  
		this.ccEnabled = false;  
	}  
	
	private void SetCustomCursor()  
	{  
		//Replace the 'cursorTexture' with the cursor    
		Cursor.SetCursor(this.cursorTexture, new Vector2(this.cursorTexture.width / 2, this.cursorTexture.height / 2), CursorMode.Auto);  
		Debug.Log("Custom cursor has been set.");  
		//Set the ccEnabled variable to true  
		this.ccEnabled = true;  
	}  
}
