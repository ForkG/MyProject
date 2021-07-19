using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_UI_Number : MonoBehaviour
{
    public GameObject BaseObject;
    public Sprite[] Sprite_UI;
    public GameObject[] Number;
    int number;
    void Awake()
    {
        BaseObject = GameObject.Find("BaseObject");
    }
    void Update()
    {
        number = BaseObject.GetComponent<Script_BaseObjects>().getDieNumber();
        Number[0].GetComponent<Image>().sprite = Sprite_UI[number / 10];
        Number[1].GetComponent<Image>().sprite = Sprite_UI[number % 10];
    }
}
