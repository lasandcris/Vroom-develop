using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {
	[SerializeField]
	ScreenOrientation orientation;
	public virtual void StartScreen(){
		Debug.Log ("start screen " + gameObject.name);
		Screen.orientation = orientation;
	}
	public virtual void EndScreen(){
		Debug.Log ("end screen " + gameObject.name);
	}
}
