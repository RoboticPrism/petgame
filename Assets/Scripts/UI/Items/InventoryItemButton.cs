using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemButton : MonoBehaviour {

    public Item item;
    public Image image;
    public Button button;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        image.sprite = item.sprite;
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.sprite;
    }
}
