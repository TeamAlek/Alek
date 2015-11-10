using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            CameraFade.StartAlphaFade(Color.white, false, 1f, 0f, () => { Application.LoadLevel("TerminalScene"); });
        }
    }

}
