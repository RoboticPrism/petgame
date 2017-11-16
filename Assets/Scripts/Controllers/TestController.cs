using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour {

    GameController gameController;
    public Toggle nameToggle;
    public Toggle hatToggle;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CleanUpTests ()
    {
        gameController.testNaming = nameToggle.isOn;
        gameController.testHats = hatToggle.isOn;
        gameController.titleController.StartTitle();
        Destroy(gameObject);
    }
}
