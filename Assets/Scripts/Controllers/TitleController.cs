using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

    GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTitle()
    {
        gameObject.SetActive(true);
    }

    public void CleanUpTitle()
    {
        gameController.introController.StartNaming();
        Destroy(gameObject);
    }
}
