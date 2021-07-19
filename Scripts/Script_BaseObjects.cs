using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_BaseObjects : MonoBehaviour
{
    public GameObject BlackObject;
    public GameObject Camera;

    Vector2 BrithPosition;
    int DieNumber;//记录玩家所进行的游戏中，总共死亡的次数
    string SceneName;
    bool TransScene;
    void Start()
    {
        Object.DontDestroyOnLoad(this);
        BrithPosition = new Vector2(0, 0);
    }
    void Update()
    {
        if (TransScene)
        {
            PlayBlackAnimation();
            if (getBlackAnimationState() == 1)//黑幕已经完全闭合  切换场景
            {
                Debug.Log(SceneName);
                SceneManager.LoadSceneAsync(SceneName);
                this.GetComponent<Script_UI_Main>().setBackGround(0);
                this.GetComponent<Script_UI_Main>().setStyle(0);
                SceneName = "";
                TransScene = false;
            }
        }
    }
    public void nextScene(string n) 
    {
        SceneName = n;
        if(!TransScene)
            TransScene = true;
    }

    public void LoadObject()//用于切换场景时，重新加载对象
    {
        BlackObject.GetComponent<Script_BlackObject>().LoadObject();
        this.GetComponent<Script_UI>().LoadObject();
        Camera.GetComponent<Script_CameraSystem>().LoadObject();
    }
    public void PlayBlackAnimation()//播放过场动画
    {
        BlackObject.SetActive(true);
        BlackObject.GetComponent<Script_BlackObject>().PlayAnimation();
    }
    public int getBlackAnimationState()//获取过场黑幕动画的状态
    {
        return BlackObject.GetComponent<Script_BlackObject>().getAnimationState();
    }

    public void setBrith(Vector2 v)
    {
        BrithPosition = v;
    }

    public Vector2 getBrith()
    {
        return BrithPosition;
    }

    public void AddDieNumber()
    {
        DieNumber++;
    }
    public void DeleteDieNumber()
    {
        DieNumber = 0;
    }
    public int getDieNumber()
    {
        return DieNumber;
    }

}
