using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {
    [SerializeField]
    private Animator anim;

    private enum PointerStates
    {
        DEFAULT = 0,
        PETTING = 1
    }

    private const string animPointerState = "PointerState";
    private const string animGo = "Go";

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
	}

    public void SetDefaultMouse()
    {
        anim.SetTrigger(animGo);
        anim.SetInteger(animPointerState, (int)PointerStates.DEFAULT);
        Debug.Log("default mouse");
    }

    public void SetPetMouse()
    {
        anim.SetTrigger(animGo);
        anim.SetInteger(animPointerState, (int)PointerStates.PETTING);
        Debug.Log("petting mouse");
    }
}
