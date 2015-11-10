using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Terminal : MonoBehaviour {

    GameObject character;
    GameObject statusText;

    // Use this for initialization
    void Start () {
        character = GameObject.Find("Character");
        statusText = GameObject.Find("StatusText");

        //get status
        int hp = 100;

        //show status
        string template_text = statusText.GetComponent<Text>().text;
        template_text = template_text.Replace("%hp%", hp.ToString());

        statusText.GetComponent<Text>().text = template_text;
    }

    // Update is called once per frame
    void Update () {
        character.transform.Rotate(0, 1, 0, Space.World);
    }

}
