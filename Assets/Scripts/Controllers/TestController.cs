using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour {

    GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
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
        gameController.titleController.StartTitle();
        Destroy(gameObject);
    }
}
