using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour {

    public string nickname;
    public int happiness;
    public TextMesh nameTag;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NameMe(string newName)
    {
        nickname = newName;
        nameTag.text = newName;
    }
}
