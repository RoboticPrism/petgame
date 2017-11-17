using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuBar : MonoBehaviour {

    public enum states {HOME, STORE, ITEMS};
    public states selected = states.HOME;
    List<MenuItem> items;
    StoreUI storeObjects;
    ItemsUI itemObjects;
    public Animator muteButtonAnimator;
	AudioSource source;

	// Use this for initialization
	void Start () {
        // Fetch associated gameobjects
        items = new List<MenuItem>(FindObjectsOfType<MenuItem>());
        storeObjects = FindObjectOfType<StoreUI>();
        itemObjects = FindObjectOfType<ItemsUI>();
		source = GetComponent<AudioSource> ();

        // Add button listeners
        foreach (MenuItem item in items)
        {
            item.GetComponent<Button>().onClick.AddListener(() => ChangeSelected(item.assocaitedState));
        }

        // Select home button
        ChangeSelected(states.HOME);
    }

    // Set a new selected button and change things accordingly
    public void ChangeSelected(states newState)
    {
		source.PlayOneShot(source.clip);
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

    public void ToggleMute()
    {
        if(AudioListener.pause)
        {
            AudioListener.pause = false;
            muteButtonAnimator.SetTrigger("unmute");
        } else
        {
            AudioListener.pause = true;
            muteButtonAnimator.SetTrigger("mute");
        }
    }
}
