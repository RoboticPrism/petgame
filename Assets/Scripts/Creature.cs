using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour {

    public string nickname;
    public float happiness;
    public TextMesh nameTag;
    public Animator faceAnimator;
    public Animator bubbleAnimator;
    public GameObject speechBubble;

    public MenuBar menuBar;
    public Mouse mouse;
    bool mousedOver = false;
    bool mouseDown = false;
    float mouseDownTime = 0f;
    float lastAction = 0f;

    public Item currentItem = null;
    public Animator foodAnim;
    public Animator toyAnim;
    public Animator hatAnim;


    // Use this for initialization
    void Start () {
        speechBubble.SetActive(false);
        SetCurrentItem(null);
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseDown)
        {
            mouseDownTime += Time.deltaTime;
        }
        lastAction += Time.deltaTime;
	}

    IEnumerator DeleteToy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetCurrentItem(null);
    }

    IEnumerator DeleteFood(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetCurrentItem(null);
    }

    IEnumerator HideBubble(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        speechBubble.SetActive(false);
    }

    public void SetCurrentItem(Item newItem)
    {
        currentItem = newItem;
        if (newItem && newItem.type == Item.itemType.FOOD)
        {
            foodAnim.SetTrigger(newItem.name);
            toyAnim.SetTrigger("Nothing");
            StartCoroutine(DeleteFood(3f));

            speechBubble.SetActive(true);
            StartCoroutine(HideBubble(3.5f));
            bubbleAnimator.SetTrigger("Love");
        } else if (newItem && newItem.type == Item.itemType.TOY)
        {
            foodAnim.SetTrigger("Nothing");
            toyAnim.SetTrigger(newItem.name);
            StartCoroutine(DeleteToy(5f));

            speechBubble.SetActive(true);
            StartCoroutine(HideBubble(5.5f));
            bubbleAnimator.SetTrigger("Excited");
        } else if (newItem && newItem.type == Item.itemType.HAT)
        {
            hatAnim.SetTrigger(newItem.name);
        } else
        {
            foodAnim.SetTrigger("Nothing");
            toyAnim.SetTrigger("Nothing");
        }
    }

    public void RemoveHat()
    {
        hatAnim.SetTrigger("Nothing");
    }

    void FixedUpdate ()
    {
        if (currentItem)
        {
            lastAction = 0f;
            if (currentItem.type == Item.itemType.FOOD)
            {
                faceAnimator.SetBool("eating", true);
                SetHappiness(currentItem.happiness);
            }
            else
            {
                faceAnimator.SetBool("eating", false);
            }

            if (currentItem.type == Item.itemType.TOY)
            {
                SetHappiness(currentItem.happiness);
            }
        } else
        {
            faceAnimator.SetBool("eating", false);
        }

        // Pet creature
        if (mousedOver && Input.GetMouseButton(0))
        {
            lastAction = 0f;
            if (mouseDownTime > 0.2f)
            {
                speechBubble.SetActive(true);
                bubbleAnimator.SetTrigger("Love");
                SetHappiness(0.1f);
            }
        }

        if (happiness > 0)
        {
            SetHappiness(-0.01f);
        } else if (happiness < 0)
        {
            SetHappiness(0.01f);
        }

        if (lastAction > 10f)
        {
            speechBubble.SetActive(true);
            StartCoroutine(HideBubble(3f));
            bubbleAnimator.SetTrigger("Bored");
            lastAction = 0f;
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
        if (menuBar.selected != MenuBar.states.STORE)
        {
            mouseDown = true;
        }
        lastAction = 0f;
    }

    void OnMouseUp()
    {
        StartCoroutine(HideBubble(0.5f));
        if (mouseDownTime < 0.2f)
        {
            speechBubble.SetActive(true);
            StartCoroutine(HideBubble(3f));
            bubbleAnimator.SetTrigger("Anger");
            SetHappiness(-3);
        }
        mouseDown = false;
        mouseDownTime = 0f;
    }

    void OnMouseEnter()
    {
        if (menuBar.selected != MenuBar.states.STORE)
        {
            mouse.SetPetMouse();
            mousedOver = true;
        }
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
