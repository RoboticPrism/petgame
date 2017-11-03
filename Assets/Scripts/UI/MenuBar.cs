using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBar : MonoBehaviour {

    public enum states {HOME, STORE, ITEMS};
    public states selected = states.HOME;
    List<MenuItem> items;
    StoreUI storeObjects;
    ItemsUI itemObjects;

	// Use this for initialization
	void Start () {
        // Fetch associated gameobjects
        items = new List<MenuItem>(FindObjectsOfType<MenuItem>());
        storeObjects = FindObjectOfType<StoreUI>();
        itemObjects = FindObjectOfType<ItemsUI>();

        // Add button listeners
        foreach (MenuItem item in items)
        {
            item.GetComponent<Button>().onClick.AddListener(() => ChangeSelected(item.assocaitedState));
        }

        // Hide items
        storeObjects.gameObject.SetActive(false);
        itemObjects.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Set a new selected button and change things accordingly
    public void ChangeSelected(states newState)
    {

        selected = newState;

        // Highlight the selected button and dehighlight the rest
        foreach (MenuItem item in items)
        {
            if (item.assocaitedState == newState)
            {
                item.SetSelected();
            } else
            {
                item.SetUnselected();
            }
        }

        // Show or hide associated ui items
        storeObjects.gameObject.SetActive(newState == states.STORE);
        itemObjects.gameObject.SetActive(newState == states.ITEMS);
    }
}
