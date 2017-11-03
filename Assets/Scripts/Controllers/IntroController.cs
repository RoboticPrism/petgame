using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

    GameController gameController;
    public InputField input;
    public Creature creature;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNaming ()
    {
        creature.gameObject.SetActive(true);
        if (gameController.namingVersion == GameController.testNaming.custom)
        {
            gameObject.SetActive(true);
        } else
        {
            CleanUpNaming();
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
        gameController.StartGame();
        Destroy(gameObject);
    }
}
