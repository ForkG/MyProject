using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TransmitPoint : MonoBehaviour
{
    public Transform Texiao;
    GameObject SystemObject;

    float random;
    void Awake()
    {
        SystemObject = GameObject.Find("GameSystem");
    }

    void FixedUpdate()
    {
        if (SystemObject.GetComponent<Script_SystemObject>().ifTransmit)
        {
            if(random < 2.5f) random+= 0.05f;
        }
        else
        {
            if (random > 0) random -= 0.05f;
        }

        Texiao.localScale = new Vector3(2.5f, 100, 1);
    }
}
