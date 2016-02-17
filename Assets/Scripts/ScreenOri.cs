using UnityEngine;
using System.Collections;

public class ScreenOri : MonoBehaviour {
    [SerializeField]
    ScreenOrientation orientation;
    // Use this for initialization
    void Start () {
        Screen.orientation = orientation;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
