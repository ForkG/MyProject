using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GamingSave : MonoBehaviour
{
    public Transform Texiao;
    public LayerMask PlayerLayer;

    GameObject SystemObject;

    float n;
    bool Saved;//玩家是否已经在这个点记录过

    void Awake()
    {
        SystemObject = GameObject.Find("GameSystem");
    }
    void Start()
    {
        Texiao.localScale = new Vector2(0,100);
    }

    void Update()
    {
        if (Saved)
        {
            if (n < 1) n += 0.05f;
            Texiao.transform.localScale = new Vector2(n, 100);
        }else if(Physics2D.OverlapCircle(transform.position, 0.07f, PlayerLayer))
        {
            Saved = true;
            SystemObject.GetComponent<Script_SystemObject>().setBrithPosition(new Vector2(transform.position.x,transform.position.y));
        }
    }
}
