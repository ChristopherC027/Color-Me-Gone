using UnityEngine; 
using System.Collections; 
public class PreLevel2GUI : MonoBehaviour {
	private float buttonW = 100; 
	private float buttonH = 50; 

	private float halfScreenW; 
	private float halfButtonW; 
	private float thirdScreenW; 
	private float halfScreenH; 

	public GUISkin customSkin; 

	private void Start() {
		halfScreenW = Screen.width/2; 
		halfButtonW = buttonW/2; 
		thirdScreenW = Screen.width/3;
		halfScreenH = Screen.height/2;
	}

	private void OnGUI() {
		GUI.skin = customSkin; 
		if(GUI.Button(new Rect(halfScreenW-thirdScreenW, halfScreenH, buttonW, buttonH), "Proceed")){
			Application.LoadLevel("Level2");
		}
	}

}