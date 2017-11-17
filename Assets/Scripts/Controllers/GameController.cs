using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool testNaming;
    public bool testHats;
    public GameObject gameUIObjects;
    public TestController testController;
    public IntroController introController;
    public TitleController titleController;
    
    public Creature creature;

    void Awake() {
        AudioListener.pause = false;
        Debug.Log("AAAH");
    }

	// Use this for initialization
	void Start () {
        // Hide all UIs except the AB test UI, which we start with
        testController.gameObject.SetActive(true);
        introController.gameObject.SetActive(false);
        titleController.gameObject.SetActive(false);
        gameUIObjects.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        gameUIObjects.SetActive(true);
    }
}
