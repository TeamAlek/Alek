using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraFade.StartAlphaFade(Color.white, true, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    //buttonなどのUI用．publicにしないとイベント設定できない
    public void moveScene(string scenename)
    {
        CameraFade.StartAlphaFade(Color.white, false, 1f, 0f, () => { Application.LoadLevel(scenename); });
    }
}
