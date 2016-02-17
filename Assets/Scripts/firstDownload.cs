using UnityEngine;
using System.Collections;
using System.Net;
using System;


public class firstDownload : MenuScreen {
    [SerializeField]
    int amountDone;
    string url_left;
    string url_right;
    WWW _leftURL;
    WWW _rightURL;
    int count = 0;
	bool running;
	bool downloading;
    // Use this for initialization
    public override void StartScreen ()
	{
		base.StartScreen ();
        GlobalVariables.getInst().reset();
		//StopCoroutine (urlTexture());
		//StartCoroutine(urlTexture());
		running = true;
		count = 0;
    }
	public override void EndScreen ()
	{
		base.EndScreen ();
		//StopCoroutine (urlTexture());
		running = false;
	}

	void Update(){
		if (running) {
			if (!downloading) {

				if (GlobalVariables.getInst ().getQRData () == null) {
					url_left = "http://82.4.70.98/allusers/_vroom_t/00024/" + (count + 1).ToString () + "_01.jpg";
					url_right = "http://82.4.70.98/allusers/_vroom_t/00024/" + (count + 1).ToString () + "_02.jpg";
				} else {
					url_left = GlobalVariables.getInst ().getQRData () + (count + 1).ToString () + "_01.jpg";
					url_right = GlobalVariables.getInst ().getQRData () + (count + 1).ToString () + "_02.jpg";
				}
				Debug.LogError (url_left);
				if (RemoteFileExists (url_left) == false) {
					Debug.LogError ("last file");

					GlobalVariables.getInst ().setnRooms (count - 1);

					running = false;
					Contoler.getInst ().ShowRoom (screens.Activate);
				} else {
					try {
						_leftURL = new WWW (url_left);
						_rightURL = new WWW (url_right);
						downloading =true;

						Debug.LogError ("GOT FILE");
					} catch (Exception) {
						Contoler.getInst ().ShowRoom (screens.LoadingScreen);
					}
				}
			} else {
				if (_leftURL.isDone && _rightURL.isDone) {
					//GlobalVariables.left[i] = _leftURL.texture;
					GlobalVariables.getInst ().setLeft (count, _leftURL.texture);
					//GlobalVariables.right[i] = _rightURL.texture;
					GlobalVariables.getInst ().setRight (count, _rightURL.texture);
					amountDone += count;
					count++;
					downloading = false;
				}
			}
		}
	}

    //have a debug timmer or thread?
   /* IEnumerator urlTexture() // add more debugging
    {
        Debug.Log("urlTexture started");
        
        count = 0;
		running = true;

		while (running) // for (int i = 1; i < GlobalVariables.numberof texters;i++) ?
        {
			Debug.LogError ("SPIN");
            //int g = count + 1;
            //cash stuff?
			if (GlobalVariables.getInst ().getQRData () == null) {
				url_left = "http://82.4.70.98/allusers/_vroom_t/00024/" + (count + 1).ToString () + "_01.jpg";
				url_right = "http://82.4.70.98/allusers/_vroom_t/00024/" + (count + 1).ToString () + "_02.jpg";
			} else {
				url_left = GlobalVariables.getInst ().getQRData () + (count + 1).ToString () + "_01.jpg";
				url_right = GlobalVariables.getInst ().getQRData () + (count + 1).ToString () + "_02.jpg";
			}
			Debug.LogError (url_left);
			if (RemoteFileExists (url_left) == false) {
				Debug.LogError ("last file");
				//GlobalVariables.nRooms = i - 1;
				GlobalVariables.getInst ().setnRooms (count - 1);
				//Application.LoadLevel("ActivateCardboard"); //not stopping coroutine - think causing memory leak
				//Application.LoadLevel("Vroom");
				running = false;
				Contoler.getInst ().ShowRoom (screens.Activate);
			} else {
				try{
				_leftURL = new WWW (url_left);
				_rightURL = new WWW (url_right);


					Debug.LogError("GOT FILE");
				}catch(Exception){
					Contoler.getInst ().ShowRoom (screens.ScanResult);
				}
				yield return _leftURL;
				yield return _rightURL;

				//GlobalVariables.left[i] = _leftURL.texture;
				GlobalVariables.getInst ().setLeft (count, _leftURL.texture);
				//GlobalVariables.right[i] = _rightURL.texture;
				GlobalVariables.getInst ().setRight (count, _rightURL.texture);
				amountDone += count;
				count++;
			}

        }
		
    }*/

    private bool RemoteFileExists(string url)
    {
        try
        {
            //Creating the HttpWebRequest
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //Setting the Request method HEAD, you can also use GET too.
            request.Method = "HEAD";
            //Getting the Web Response.
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Returns TRUE if the Status code == 200
            response.Close();
            return (response.StatusCode == HttpStatusCode.OK);
        }
        catch
        {
           // if (response.StatusCode == HttpStatusCode.NotFound)
                return false;
        }
    }


}
