using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BirthObject : MonoBehaviour
{
    //初始化重生坐标
    GameObject SystemObject;

    void Awake()
    {
        SystemObject = GameObject.Find("GameSystem");
    }
    void Start()
    {
        SystemObject.GetComponent<Script_SystemObject>().setBrithPosition(new Vector2(transform.position.x, transform.position.y));
    }
}
