using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

    public InputField input;
    public Button button;
    public Creature creature;

	// Use this for initialization
	void Start () {
        StartNaming();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNaming ()
    {
        input.gameObject.SetActive(true);
    }

    public void EndNaming ()
    {
        if (input.text != "")
        {
            creature.NameMe(input.text);
            Destroy(input.gameObject);
            Destroy(button.gameObject);
            Destroy(gameObject);
        }
    }
}
