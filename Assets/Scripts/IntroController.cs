using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

    public GameController gameController;
    public GameObject introObjects;
    public InputField input;
    public Creature creature;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNaming ()
    {
        creature.gameObject.SetActive(true);
        if (gameController.namingVersion == GameController.testNaming.custom)
        {
            introObjects.SetActive(true);
        } else
        {
            EndNaming();
        }
    }

    public void EndNaming ()
    {
        if (input.text != "")
        {
            creature.NameMe(input.text);
            CleanUpNaming();
        }
    }

    public void CleanUpNaming ()
    {
        Destroy(introObjects);
        Destroy(gameObject);
    }
}
