using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_SystemObject : MonoBehaviour
{
    public Transform InitialBrith;

    GameObject Transmit;
    GameObject Player;
    GameObject BlackObject;
    GameObject BaseObject;

    public int setUI;
    public int setBackGround;
    public string nextSceneName;

    public bool BlackAnimatorEnd;
    public bool GameStop;
    public bool ifTransmit;

    public bool ifPlayerControl;//玩家当前是否可操作
    void Awake()
    {
        Transmit = GameObject.Find("TransmitPoint");
        Player = GameObject.Find("Player");
        BlackObject = GameObject.Find("BlackObject");
        BaseObject = GameObject.Find("BaseObject");
    }
    void Start()
    {
        BaseObject.GetComponent<Script_BaseObjects>().LoadObject();
        BaseObject.GetComponent<Script_UI_Main>().setStyle(setUI);
        BaseObject.GetComponent<Script_UI_Main>().setBackGround(setBackGround);
    }

    public void nextScene(string t)
    {
        if(t == "")
            BaseObject.GetComponent<Script_BaseObjects>().nextScene(nextSceneName);
        else
            BaseObject.GetComponent<Script_BaseObjects>().nextScene(t);
    }

    public void PlayBlackAnimation()//播放过场动画
    {
        BaseObject.GetComponent<Script_BaseObjects>().PlayBlackAnimation();
    }
    public int getBlackAnimationState()//获取过场黑幕动画的状态
    {
        return BaseObject.GetComponent<Script_BaseObjects>().getBlackAnimationState();
    }

    public void setBrithPosition(Vector2 v)//设置重生坐标
    {
        BaseObject.GetComponent<Script_BaseObjects>().setBrith(v);
    }

    public Vector2 getBrithPosition()//获取重生坐标
    {
        if (BaseObject.GetComponent<Script_BaseObjects>().getBrith().x == 0 && BaseObject.GetComponent<Script_BaseObjects>().getBrith().y == 0)
            return new Vector2(InitialBrith.position.x, InitialBrith.position.y);
        else
            return BaseObject.GetComponent<Script_BaseObjects>().getBrith();
    }

    public void AddDieNumber()
    {
        BaseObject.GetComponent<Script_BaseObjects>().AddDieNumber();
    }
}
