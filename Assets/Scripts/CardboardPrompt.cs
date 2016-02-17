using UnityEngine;
using System.Collections;

public class CardboardPrompt : MenuScreen {
    [SerializeField]
    GameObject yesButton;
    [SerializeField]
    GameObject noButton;
	public override void StartScreen ()
	{
		base.StartScreen ();
		yesButton.SetActive (false);
		noButton.SetActive (false);

		string key = "firstRun";
		bool hasKey = PlayerPrefs.HasKey(key);  //dont think this is ever set

        //sees if its been run before to skip
		if (hasKey) {
			//Debug.Log ("We have a Key!");
			//Application.LoadLevel("PromptScan");
			Contoler.getInst().ShowRoom(screens.promptScan);
		} else {
			//Debug.Log ("We don't have a key");
			yesButton.SetActive(true);
			noButton.SetActive(true);
		}
	
	}
}
