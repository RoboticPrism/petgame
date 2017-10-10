using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public enum testNaming {none, custom}
    public testNaming namingVersion;

    public TestController testController;
    public IntroController introController;
    public GameObject titleObjects;
    public Creature creature;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTitle ()
    {
        titleObjects.SetActive(true);
    }

    public void CleanUpTitle ()
    {
        Destroy(titleObjects);
        introController.StartNaming();
    }
}
