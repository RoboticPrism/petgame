using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour {
    // Other controllers
    public ItemsUI itemsUI;
    public MoneyBar moneyBar;

    // Item list vars
    public List<Item> itemsToSell;
    public List<StoreItemButton> itemButtons = new List<StoreItemButton>();
    public GameObject contentPane;
    public StoreItemButton itemPrefab;

    // Dialog vars
    public GameObject fullText;
    public GameObject itemBox;
    public Image itemImage;
    public Text itemPrice;
    public Button acceptButton;
    public Button cancelButton;

    // Use this for initialization
    void Start () {
        // Add each item to sell as a buy button
        foreach (Item item in itemsToSell)
        {
            GameObject newButton = Instantiate(itemPrefab.gameObject, contentPane.transform);
            newButton.GetComponent<StoreItemButton>().SetItem(item);
            newButton.GetComponent<Button>().onClick.AddListener(() => SetSelectedItem(item));
            itemButtons.Add(newButton.GetComponent<StoreItemButton>());
        }
        ArrangeButtons();

        // Show and hide text box items
        fullText.GetComponent<Text>().text = "Welcome!";
        fullText.gameObject.SetActive(true);
        itemBox.gameObject.SetActive(false);

        // Add listener for cancel button
        cancelButton.onClick.AddListener(() => CancelPurchase());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable ()
    {
        fullText.GetComponent<Text>().text = "Welcome!";
        fullText.gameObject.SetActive(true);
        itemBox.gameObject.SetActive(false);
    }

    public void SetSelectedItem(Item selectedItem)
    {
        itemImage.sprite = selectedItem.sprite;
        itemPrice.text = selectedItem.price.ToString();
        
        fullText.gameObject.SetActive(false);
        itemBox.gameObject.SetActive(true);

        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(() => BuySelectedItem(selectedItem));
    }

    public void BuySelectedItem(Item selectedItem)
    {
        // remove cash
        if (moneyBar.money - selectedItem.price >= 0)
        {
            moneyBar.SetMoney(moneyBar.money - selectedItem.price);
            itemsUI.AddItem(selectedItem);
            RemoveStoreButton(selectedItem);
            fullText.GetComponent<Text>().text = "Thank you!";
            fullText.gameObject.SetActive(true);
            itemBox.gameObject.SetActive(false);
        } else
        {
            fullText.GetComponent<Text>().text = "Sorry, you can't afford that item.";
            fullText.gameObject.SetActive(true);
            itemBox.gameObject.SetActive(false);
        }
        
    }

    public void CancelPurchase()
    {
        fullText.GetComponent<Text>().text = "Welcome!";
        fullText.gameObject.SetActive(true);
        itemBox.gameObject.SetActive(false);
    }

    public void RemoveStoreButton(Item selectedItem)
    {
        itemsToSell.Remove(selectedItem);
        StoreItemButton buttonToRemove = null;
        foreach(StoreItemButton itemButton in itemButtons)
        {
            if (itemButton.item == selectedItem)
            {
                buttonToRemove = itemButton;
                break;
            }
        }
        if (buttonToRemove != null)
        {
            itemButtons.Remove(buttonToRemove);
            Destroy(buttonToRemove.gameObject);
            ArrangeButtons();
        }
    }

    public void ArrangeButtons()
    {
        int i = 0;
        foreach (StoreItemButton itemButton in itemButtons)
        {
            itemButton.GetComponent<RectTransform>().offsetMin = new Vector2(10 + (100 * i), 0);
            i++;
        }
    }
}
