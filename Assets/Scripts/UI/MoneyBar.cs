using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour {

    public int money = 300;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMoney(int newMoney)
    {
        money = newMoney;
        text.text = newMoney.ToString();
    }
}
