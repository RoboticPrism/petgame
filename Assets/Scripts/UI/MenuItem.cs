using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour {

    public MenuBar.states assocaitedState;
    public static int offset = 30;
    RectTransform rect;
    RectTransform scaler;

	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
        scaler = transform.GetChild(0).GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Lowers the button to show it as selected
    public void SetSelected()
    {
        rect.offsetMin = new Vector2(0, -offset);
        scaler.offsetMax = new Vector2(0, -offset);
    }

    // Raises a button back up to show it as deselected
    public void SetUnselected()
    {
        rect.offsetMin = new Vector2(0, 0);
        scaler.offsetMax = new Vector2(0, 0);
    }
}
