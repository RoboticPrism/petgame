using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour {

    public string nickname;
    public float happiness;
    public TextMesh nameTag;
    public Animator faceAnimator;

    public Mouse mouse;
    bool mousedOver = false;

    public Item currentItem = null;
    public SpriteRenderer foodImage;
    public SpriteRenderer toyImage;
    public SpriteRenderer hatImage;


    // Use this for initialization
    void Start () {
        mouse = FindObjectOfType<Mouse>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator deleteToy()
    {
        yield return new WaitForSeconds(5);
        SetCurrentItem(null);
    }

    IEnumerator deleteFood()
    {
        yield return new WaitForSeconds(3);
        SetCurrentItem(null);
    }

    public void SetCurrentItem(Item newItem)
    {
        currentItem = newItem;
        if (newItem && newItem.type == Item.itemType.FOOD)
        {
            foodImage.sprite = newItem.sprite;
            toyImage.sprite = null;
            StartCoroutine(deleteFood());
        } else if (newItem && newItem.type == Item.itemType.TOY)
        {
            foodImage.sprite = null;
            toyImage.sprite = newItem.sprite;
            StartCoroutine(deleteToy());
        } else if (newItem && newItem.type == Item.itemType.HAT)
        {
            hatImage.sprite = newItem.sprite;
        } else {
            foodImage.sprite = null;
            toyImage.sprite = null;
        }
    }

    void FixedUpdate ()
    {
        if (currentItem)
        {
            if (currentItem.type == Item.itemType.FOOD)
            {
                faceAnimator.SetBool("eating", true);
                SetHappiness(0.1f);
            }
            else
            {
                faceAnimator.SetBool("eating", false);
            }

            if (currentItem.type == Item.itemType.TOY)
            {
                SetHappiness(0.1f);
            }
        } else
        {
            faceAnimator.SetBool("eating", false);
        }

        // Pet creature
        if (mousedOver && Input.GetMouseButton(0))
        {
            SetHappiness(0.1f);
        }

        if (happiness > 0)
        {
            SetHappiness(-0.01f);
        } else if (happiness < 0)
        {
            SetHappiness(0.01f);
        }
    }

    void SetHappiness(float difference)
    {
        happiness += difference;
        if (happiness < -15)
        {
            happiness = -15;
        } else if (happiness > 15)
        {
            happiness = 15;
        }

        faceAnimator.SetInteger("happiness", (int)happiness);
    }

    void OnMouseDown()
    {
        SetHappiness(-1);
    }


    void OnMouseEnter()
    {
        mouse.SetPetMouse();
        mousedOver = true;
    }

    void OnMouseExit()
    {
        mouse.SetDefaultMouse();
        mousedOver = false;
    }

    public void NameMe(string newName)
    {
        nickname = newName;
        nameTag.text = newName;
    }
}
