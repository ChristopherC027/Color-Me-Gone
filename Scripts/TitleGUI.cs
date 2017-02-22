using UnityEngine; 
using System.Collections; 
public class TitleGUI : MonoBehaviour {
	private float buttonW = 100; 
	private float buttonH = 50; 

	private float halfScreenW; 
	private float halfButtonW; 
	private float thirdScreenW;
	private float halfScreenH; 
	private float fourthScreenH; 

	public GUISkin customSkin; 

	private void Start() {
		halfScreenW = Screen.width/2; 
		halfButtonW = buttonW/2; 
		thirdScreenW = Screen.width/3; 
		halfScreenH = Screen.height/2; 
		fourthScreenH = Screen.height/4;
	}

	private void OnGUI() {
		GUI.skin = customSkin; 
		if(GUI.Button(new Rect(halfScreenW-thirdScreenW, halfScreenH, buttonW, buttonH), "Credits")){
			Application.LoadLevel("Credits");
		}
		if(GUI.Button(new Rect(halfScreenW-thirdScreenW, fourthScreenH, buttonW, buttonH), "Story")){
			Application.LoadLevel("Story");
		}
		if(GUI.Button(new Rect((halfScreenW - halfButtonW) +thirdScreenW, halfScreenH, buttonW, buttonH), "Instructions")){
			Application.LoadLevel("Instructions"); 
		}
		if(GUI.Button(new Rect((halfScreenW - halfButtonW) +thirdScreenW, fourthScreenH, buttonW, buttonH), "Play Game")){
			Application.LoadLevel("Level1"); 
		}

	}
}
