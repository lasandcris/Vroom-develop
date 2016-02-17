using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public enum screens{
	SplashScreen,
	promptCard,
	promptScan,
	InfoScreen,
	LoadingScreen,
	Activate,
	ManualScan,
	Viwer
}
public class Contoler : MonoBehaviour {
	static Contoler inst;
	[SerializeField] List<GameObject> things = new List<GameObject>();
	[SerializeField] screens current;


	public void Start(){
		inst = this;
		disableAll ();
		ShowRoom ((int)screens.promptCard);
	}
	public void ShowRoom(screens screen){
		ShowRoom ((int)screen);
	}
	public void ShowRoom(int number){
		disableAcive ();
		things [number].SetActive (true);
		Debug.LogError ("swiched room");
		current = (screens)number;
		//things [(int)current].GetComponent<MenuScreen> ().StartScreen ();
		things[(int)(current)].SendMessage("StartScreen");
	}
	public void disableAll(){
		foreach (var screan in things) {
			screan.GetComponent<MenuScreen> ().EndScreen (); //could be made better
			screan.SetActive(false);


		}
	}
	public void disableAcive(){
		foreach (var screan in things.Where(x=>x.activeSelf ==true)) {
			screan.SendMessage("EndScreen");
			screan.SetActive(false);
			//screan.GetComponent<MenuScreen> ().EndScreen (); //could be made better

		}
	}
	public static Contoler getInst(){
		return inst;
	}
}
