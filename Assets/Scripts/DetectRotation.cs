using UnityEngine;
using System.Collections;

public class DetectRotation : MenuScreen {
    public bool rotate = false;
	public ImageHandler img;
	// Use this for initialization
	public override void StartScreen ()
	{
		base.StartScreen ();
		if (GlobalVariables.getInst ().debug) {
			//rotate = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
        //when orientation is corrent chnage scene
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || rotate) {
			//Screen.orientation = ScreenOrientation.LandscapeLeft;
			//Application.LoadLevel("Vroom"); // run VR startroom?
			img.StartScreen();
			Contoler.getInst().disableAll();

		}

    }

	public void StartVRoom(){
		Contoler.getInst().disableAll();
	}
}
