using UnityEngine;
using System.Collections;

public class MovingScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public指定しないとprivate扱いになってボタンに登録できない
    public void moveScene(string scenetext)
    {
        CameraFade.StartAlphaFade(Color.white, false, 1f, 0f, () => { Application.LoadLevel(scenetext); });
    }
}
