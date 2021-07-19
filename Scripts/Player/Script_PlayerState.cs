using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_PlayerState : MonoBehaviour
{
    GameObject SystemObject;

    bool ifControl;
    bool PlayerRisk;
    bool ifEnd;

    void Awake()
    {
        SystemObject = GameObject.Find("GameSystem");
    }

    void Start()
    {
        transform.position = SystemObject.GetComponent<Script_SystemObject>().getBrithPosition();
    }

    void Update()
    {
        if (SystemObject.GetComponent<Script_SystemObject>().GameStop || PlayerRisk || ifEnd)
            ifControl = false;
        else
            ifControl = true;

        if (this.GetComponent<Script_PlayerAnimator>().ifEnd)
        {
            SystemObject.GetComponent<Script_SystemObject>().AddDieNumber();
            SystemObject.GetComponent<Script_SystemObject>().nextScene("");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!PlayerRisk)
            if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
            {
               // Scene scene = SceneManager.GetActiveScene();
                SystemObject.GetComponent<Script_SystemObject>().nextScene("ChoiceScene");
                SystemObject.GetComponent<Script_SystemObject>().AddDieNumber();
                PlayerRisk = true;
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!SystemObject.GetComponent<Script_SystemObject>().ifTransmit)
        {
            if(collision.gameObject.layer == 12)
            {
                Debug.Log("1111");
                ifEnd = true;
            }
        }
    }

    public bool getState_End()
    {
        return ifEnd;
    }
    public bool getState_Risk()
    {
        return PlayerRisk;
    }
    public bool getState_GameStop()
    {
        return SystemObject.GetComponent<Script_SystemObject>().GameStop;
    }
    public bool getState_Control()
    {
        return ifControl;
    }
}
