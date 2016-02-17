using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[RequireComponent(typeof(Collider))]
using System;

public class ScanFunctions : MenuScreen{


	//float timer = 0;
	
	// Use this for initialization
	
	void Awake()
	{
		EasyCodeScanner.Initialize();
		EasyCodeScanner.OnScannerMessage += OnScannerMessage;
		EasyCodeScanner.OnScannerEvent += OnScannerEvent;
	}
	//public GameObject testPlane;


	public override void StartScreen ()
	{
		base.StartScreen ();
		if (GlobalVariables.getInst ().debug) {
			startScanning ();
		}
	}

	void Update(){
	}

	void OnDestroy()
	{
        //removes events on GameObject destroy - run stopScanning?
        EasyCodeScanner.OnScannerMessage -= OnScannerMessage;
		EasyCodeScanner.OnScannerEvent -= OnScannerEvent;
	}
	void loadNextRoom(){
		Contoler.getInst ().ShowRoom ((int)screens.LoadingScreen);
	}
	public void ScipScanning(){
		Contoler.getInst ().ShowRoom ((int)screens.ManualScan);
	}
	public void startScanning() //run on UI button press
	{
        //Debug.Log ("Ehy");
        //		testText.GetComponent<Text> ().text = "start scanning";
        //		testText.GetComponent<TextMesh> ().text = "pressed";
		Debug.Log("start");
#if UNITY_EDITOR
		loadNextRoom();
#else
        //sets up CodeScanner
        //EasyCodeScanner.Initialize();
        //launches the scanner
		try{
		EasyCodeScanner.launchScanner (true, "Scanning...", -1, false);
		//loadNextRoom();
		}catch(Exception){
		}
        //bindes events
		//EasyCodeScanner.OnScannerMessage += OnScannerMessage;
		//EasyCodeScanner.OnScannerEvent += OnScannerEvent;
		//EasyCodeScanner.OnDecoderMessage += OnDecoderMessage;
#endif

	}
	public void stopScanning()
	{
        //removes events on GameObject destroy
        EasyCodeScanner.OnScannerMessage -= OnScannerMessage;
		EasyCodeScanner.OnScannerEvent -= OnScannerEvent;
		//EasyCodeScanner.OnDecoderMessage -= OnDecoderMessage;
	}

	public void mainMenu(){
		//Application.LoadLevel ("Link_01");
	}
	public void nextScene(){

		//Application.LoadLevel("VRoom");
	}

	public void VRScene(){
		//Application.LoadLevel ("VRoom");
	}


	void OnScannerMessage(string data) //event from EasyCodeScanner
    {
		Debug.Log("scanner " + data);
        //GlobalVariables.QRData = data;
        GlobalVariables.getInst().setQRData(data);

       // Application.LoadLevel ("ScanResult");
		loadNextRoom();
		//stopScanning ();
		//StartCoroutine (f (GlobalVariables.QRData, testText));


		//Application.LoadLevel ("RoomMenu");
		//Debug functions for acquired data
		//navigateButtonText.GetComponent<Text> ().text = GlobalVariables.QRData;

	
	}
		

	void OnScannerEvent(string eventStr){
		//Debug.Log("EasyCodeScannerExample - onScannerEvent:"+eventStr);
	}
	
	//Callback when decodeImage has decoded the image/texture 
	void OnDecoderMessage(string data){
		//Debug.Log("EasyCodeScannerExample - onDecoderMessage data:"+data);
		
		//dataStr = data;
	}







	
}
