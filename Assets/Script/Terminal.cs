using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {

    GameObject character;
    float theta = 0.1f;
    // Use this for initialization
    void Start () {
        character = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
        character.transform.Rotate(0, 1, 0, Space.World);
    }

}
