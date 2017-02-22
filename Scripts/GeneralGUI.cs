using UnityEngine; 
using System.Collections; 
public class GeneralGUI : MonoBehaviour {
	private float buttonW = 150; 
	private float buttonH = 50; 

	private float halfScreenW; 
	private float halfButtonW; 

	public GUISkin customSkin; 
	public float thirdScreenH;

	private void Start() {
		halfScreenW = Screen.width/2; 
		thirdScreenH = Screen.height/1.1f; 
		halfButtonW = buttonW/2; 
	}

	private void OnGUI() {
		GUI.skin = customSkin; 
		if(GUI.Button(new Rect(halfScreenW-halfButtonW, thirdScreenH, buttonW, buttonH), "Title Screen")){
			Application.LoadLevel("Intro"); 
		}
	}
}