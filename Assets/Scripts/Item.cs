using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int price;
    public enum itemType { FOOD, TOY, HAT };
    public itemType type;
    public Sprite sprite;
}
