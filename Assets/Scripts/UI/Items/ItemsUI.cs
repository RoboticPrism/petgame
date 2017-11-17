using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUI : MonoBehaviour {
    public GameController gameController;

    // Item list vars
    public List<Item> itemsOwned;
    public List<InventoryItemButton> itemButtons = new List<InventoryItemButton>();
    public GameObject contentPane;
    public InventoryItemButton itemPrefab;
    public Button removeHatButton;

    public Creature creature;

    // Use this for initialization
    void Start () {
        if(!gameController.testHats)
        {
            removeHatButton.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item selectedItem)
    {
        itemsOwned.Add(selectedItem);
        GameObject newButton = Instantiate(itemPrefab.gameObject, contentPane.transform);
        newButton.GetComponent<InventoryItemButton>().SetItem(selectedItem);
        newButton.GetComponent<Button>().onClick.AddListener(() => creature.SetCurrentItem(selectedItem));
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

    public void RemoveHat()
    {
        creature.RemoveHat();
    }
}
