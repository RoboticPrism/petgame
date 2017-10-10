using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour {

    public GameController gameController;
    public GameObject testingObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseNoNaming()
    {
        gameController.namingVersion = GameController.testNaming.none;
    }

    public void ChooseCustomNaming()
    {
        gameController.namingVersion = GameController.testNaming.custom;
    }

    public void CleanUpTests ()
    {
        Destroy(testingObjects);
        gameController.StartTitle();
        Destroy(gameObject);
    }
}
