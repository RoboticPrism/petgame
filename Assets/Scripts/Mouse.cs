using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {

    Image image;

    public Sprite mouseSprite;
    public Sprite mousePetSprite;

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
	}

    public void SetDefaultMouse()
    {
        image.sprite = mouseSprite;
    }

    public void SetPetMouse()
    {
        image.sprite = mousePetSprite;
    }
}
