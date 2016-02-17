using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Collider))]
using System;


public class ImageHandler : MenuScreen {
	public GameObject leftSphere;
	public GameObject rightSphere;

    int current = 0;
	public float runningFor;
	float runningtime =10;
    //bool _update = true;
    [SerializeField] bool leave = false;
	public bool showing = false;
    void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 20), GlobalVariables.nRooms.ToString());
        GUI.Label(new Rect(10, 10, 100, 20), GlobalVariables.getInst().getnRooms().ToString());
        GUI.Label(new Rect(10, 10, 100, 20), current.ToString());
    }
		
	public void Start(){
	}
	public override void StartScreen ()
	{
		base.StartScreen ();
		//Cardboard.SDK.VRModeEnabled = true;
        //Screen.orientation = ScreenOrientation.LandscapeLeft;

		try{
        //leftSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.left[0];
        leftSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.getInst().getLeft(0);
        //rightSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.right[0];
        rightSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.getInst().getRight(0);
		}
		catch(Exception){
		}
		if (GlobalVariables.getInst ().debug) {
			runningFor = 0;
			leave = false;
			//Contoler.getInst().ShowRoom(screens.promptScan);
		}
		showing = true;
    }

	public override void EndScreen ()
	{
		base.EndScreen ();
		//Cardboard.SDK.VRModeEnabled = false;
	}
	public void nextRoom(){
        current++;

        //if (current > GlobalVariables.nRooms)
        if (current > GlobalVariables.getInst().getnRooms())

            current = 0;

        //Destroy(leftSphere.GetComponent<Renderer>().material.mainTexture);
        //Destroy(rightSphere.GetComponent<Renderer>().material.mainTexture);

        //leftSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.left[current];
        leftSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.getInst().getLeft(current);
        //rightSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.right[current];
        rightSphere.GetComponent<Renderer>().material.mainTexture = GlobalVariables.getInst().getRight(current);


    }

	public void quitApp()
	{
        //Application.UnloadLevel("Vroom");
        //Resources.UnloadUnusedAssets();
        //Application.LoadLevel("PromptScan");

		//Application.Quit();

	}


    void Update()
    {
		if (showing) {
			/*if (GlobalVariables.getInst ().debug) {
			if (runningFor > runningtime) {
				Contoler.getInst().ShowRoom(screens.promptScan);
			} else {
				runningFor += Time.deltaTime;
			}
		}
        else*/
			if (Input.deviceOrientation == DeviceOrientation.Portrait || leave) {

				Destroy (leftSphere.GetComponent<Renderer> ().material.mainTexture);
				Destroy (rightSphere.GetComponent<Renderer> ().material.mainTexture);

				//_update = false;

				//Application.Quit();
				//Application.UnloadLevel("Vroom");
				// Resources.UnloadUnusedAssets();
				//Application.LoadLevel("PromptScan");
				Contoler.getInst ().ShowRoom (screens.promptScan);
				EndScreen ();
				showing = false;

			}
		}

    }
}
