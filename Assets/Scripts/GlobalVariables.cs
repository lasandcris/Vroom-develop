using UnityEngine;
using System.Collections;

public class GlobalVariables: MonoBehaviour
{
    [SerializeField]
    static GlobalVariables inst;
    [SerializeField]
    Texture2D[] left = new Texture2D[10]; //set number to max texture number or chnage to list
    [SerializeField]
    Texture2D[] right = new Texture2D[10];
    [SerializeField]
    int nRooms = 0;
    [SerializeField]
    string QRData;

	public bool debug = false;

    public void Awake()
    {
        inst = this;
        DontDestroyOnLoad(gameObject);
    }
    public static GlobalVariables getInst()
    {
        if(inst)
        return inst;
        else
        {
            GameObject GL = new GameObject();
            GL.AddComponent<GlobalVariables>();
            GL.name = "GlobalVariables";
            return GL.GetComponent<GlobalVariables>();
        }
    }
    public void reset()
    {
		foreach (var tex in left) {
			Destroy (tex);
		}
		foreach (var tex in right) {
			Destroy (tex);
		}
        left = new Texture2D[10];
        right = new Texture2D[10];
        nRooms = 0;
		Resources.UnloadUnusedAssets();
	

    }
    public Texture2D getLeft(int num)
    {
        return left[num];
    }
    public Texture2D getRight(int num)
    {
        return right[num];
    }
    public int getnRooms()
    {
        return nRooms;
    }
    public void setnRooms(int num)
    {
        nRooms = num;
    }
    public string getQRData()
    {
        return QRData;
    }
    public void setQRData(string Data)
    {
        QRData = Data;
    }
    public void setLeft(int num, Texture2D tex)
    {
        left[num] = tex;
    }
    public void setRight(int num, Texture2D tex)
    {
        right[num] = tex;
    }
}
