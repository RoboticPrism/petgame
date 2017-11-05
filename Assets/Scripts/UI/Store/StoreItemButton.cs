using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemButton : MonoBehaviour {

    public Item item;
    public Image image;
    public Button button;
    public Text priceText;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        image.sprite = item.sprite;
        priceText.text = item.price.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.sprite;
        priceText.text = newItem.price.ToString();
    }
}
