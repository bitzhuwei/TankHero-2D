using UnityEngine;
using System.Collections;

public class TargetCursor : MonoBehaviour {
	//3D贴图是Material,2D贴图是Texture
	public Texture CurosrTexture;
	
	//OnGUI is called for rendering and handling GUI events.
	//渲染和处理GUI事件时调用。 	
	//This means that your OnGUI implementation might be called several times per frame (one call per event). For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is set to false, OnGUI() will not be called.
	//这意味着你的OnGUI程序将会在每一帧被调用。要得到更多的GUI事件的信息查阅Event手册。如果Monobehaviour的enabled属性设为false，OnGUI()将不会被调用。
	void OnGUI() { //	渲染GUI和处理GUI时调用。
		if (CurosrTexture != null) {
            var depth = GUI.depth;
            GUI.depth = depth - 1;
			// 计算图片左上角的坐标
			float left = Input.mousePosition.x - CurosrTexture.width / 2;
			float top = Screen.height - Input.mousePosition.y - CurosrTexture.height / 2;
			
			GUI.DrawTexture(new Rect(left, top, CurosrTexture.width, CurosrTexture.height), CurosrTexture);
            //Debug.Log(string.Format("Cursor GUI depth: {0}", GUI.depth));
		}
	}


}
