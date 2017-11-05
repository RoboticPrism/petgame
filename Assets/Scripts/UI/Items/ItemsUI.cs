using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUI : MonoBehaviour {

    // Item list vars
    public List<Item> itemsOwned;
    public List<InventoryItemButton> itemButtons = new List<InventoryItemButton>();
    public GameObject contentPane;
    public InventoryItemButton itemPrefab;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item selectedItem)
    {
        itemsOwned.Add(selectedItem);
        GameObject newButton = Instantiate(itemPrefab.gameObject, contentPane.transform);
        newButton.GetComponent<InventoryItemButton>().SetItem(selectedItem);
        itemButtons.Add(newButton.GetComponent<InventoryItemButton>());
        ArrangeButtons();
    }

    public void ArrangeButtons()
    {
        int i = 0;
        foreach (InventoryItemButton itemButton in itemButtons)
        {
            itemButton.GetComponent<RectTransform>().offsetMin = new Vector2(10 + (100 * i), 0);
            i++;
        }
    }
}
