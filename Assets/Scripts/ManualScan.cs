using UnityEngine;
using System.Collections;

public class ManualScan : MenuScreen {
	public UnityEngine.UI.InputField Uname;
	public UnityEngine.UI.InputField Number;
	public string data = "http://82.4.70.98/allusers/";
	public string startData = "http://82.4.70.98/allusers/";
	public string startUname = "fran";
	public string startNumber = "00039";
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("UName")){
			startUname = PlayerPrefs.GetString ("UName");
		}
		if(PlayerPrefs.HasKey("Num")){
			startUname = PlayerPrefs.GetString ("Num");
		}
		Uname.text = startUname;
		Number.text = startNumber;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Go(){
		data = startData + Uname.text + "/" + Number.text + "/";
		GlobalVariables.getInst().setQRData(data);

		PlayerPrefs.SetString ("UName", Uname.text);
		PlayerPrefs.SetString ("Num", Number.text);

		Contoler.getInst ().ShowRoom ((int)screens.LoadingScreen);

	}
}
