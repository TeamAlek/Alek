using UnityEngine;
using System.Collections;
using System.IO;

public class WebCam : MonoBehaviour {

    private const string URL = "http://133.19.61.106:40005";
    private const int FPS = 30;

    private Rect screenRect;
    public WebCamTexture camTex;
    public Texture2D texture;
    public Color32[] img;

    public static string result_txt = null;

    void OnGUI()
    {
        GUI.DrawTexture(screenRect, camTex, ScaleMode.ScaleToFit);
    }

    // Use this for initialization
    void Start() {
        CameraFade.StartAlphaFade(Color.white, true, 1f, 1f);

        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTex = new WebCamTexture();
        camTex.requestedHeight = Screen.width;
        camTex.requestedWidth = Screen.height;
        camTex.Play();
    }
	
	// Update is called once per frame
	void Update() {
        img = camTex.GetPixels32();
        Texture2D texture = new Texture2D(camTex.width, camTex.height);
        texture.SetPixels32(img);

        //send screenshot
        if (Input.GetKeyDown(KeyCode.Space)){
            //convert
            Texture2D tex2d = new Texture2D(camTex.width, camTex.height);
            tex2d.SetPixels32(img);
            byte[] bytes = tex2d.EncodeToPNG();

            //send data
            StartCoroutine("accessToServer", bytes);
            //accessToServer(bytes);

            print("finish capture and send");
        }
        //debug 
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            result_txt = "test_txt";
            camTex.Stop();
            CameraFade.StartAlphaFade(Color.white, false, 1f, 0f, () => { Application.LoadLevel("SummonResultScene"); });
        }
    }

    private IEnumerator accessToServer(byte[] send_bytes)
    {
        var form = new WWWForm();
        form.AddBinaryData("fileUpload", send_bytes, "send.png", "image/png");
        var www = new WWW(URL, form);

        //受信
        yield return www; //受信待機
        if (www.error == null)
        {
            if (www.text != "null")
            {
                print("string : " + www.text);
                CameraFade.StartAlphaFade(Color.white, false, 1f, 0f, () => { Application.LoadLevel("SummonResultScene"); });
                result_txt = www.text;
            }
            else
            {
                print("QRcode not found");
            }
        }
    }

}


