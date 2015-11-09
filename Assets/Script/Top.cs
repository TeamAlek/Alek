using UnityEngine;
using System.Collections;

public class Top : MonoBehaviour {

    GameObject tower;
    float theta = 0.1f;
	// Use this for initialization
	void Start () {
        tower = GameObject.Find("Tower");
	}
	
	// Update is called once per frame
	void Update () {
        tower.transform.Rotate(0, 1, 0, Space.World);
    }
}
