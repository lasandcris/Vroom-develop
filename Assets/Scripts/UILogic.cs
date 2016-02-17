using UnityEngine;
using System.Collections;

public class UILogic : MonoBehaviour {

	public void no()
	{
		//Application.LoadLevel ("Help");
	}

	public void yes()
	{
		PlayerPrefs.SetString ("firstRun", "firstRun");
		PlayerPrefs.Save ();
		//Application.LoadLevel ("PromptScan");
		Contoler.getInst ().ShowRoom ((int)screens.promptScan);
	}
}
