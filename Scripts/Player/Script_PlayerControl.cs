using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_PlayerControl : MonoBehaviour
{
    public Transform Test_Object;
    public Transform TopTest_Object;
    public Transform AheadTest_Object;

    public LayerMask ColliderLayer;
    public float MoveSpeed;//玩家的移动速度
   
    Transform Player;//玩家
    int Direction;//玩家的移动方向
    int JumpTime;//玩家跳跃允许的最高高度/最长时间
    float JumpSpeed;//玩家的跳跃速度
    bool ifMove;//是否允许移动
    bool ifJump;//是否允许跳跃
    bool ifButtonJump;//是否已经按下跳跃键
    bool TestBlock;//检测方块
    bool DieJump;//玩家受伤后的跳跃行为

    void Start()
    {
        Direction = 1;
        JumpSpeed = 0;
        ifJump = false;
        Player = this.transform;
    }

    void Update()
    {
        if (this.GetComponent<Script_PlayerState>().getState_Control())
        {
            if (DieJump) DieJump = false;
            //=================移动=================
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                ifMove = true;
                if (Input.GetKey(KeyCode.A))
                    Direction = -1;
                else if (Input.GetKey(KeyCode.D))
                    Direction = 1;

                if (null == Physics2D.OverlapCircle(AheadTest_Object.position, 0.005f, ColliderLayer))//判断移动方向是否有墙壁
                {
                    Player.Translate(Direction * MoveSpeed, 0, 0);
                }
            }
            else
            {
                ifMove = false;
            }
            Player.localScale = new Vector3(Direction, 1, 1);
            //=================跳跃==================
            if (null != Physics2D.OverlapCircle(Test_Object.position, 0.02f, ColliderLayer))//判断是否接触地面
                TestBlock = true;
            else
                TestBlock = false;

            if (null != Physics2D.OverlapCircle(TopTest_Object.position, 0.02f, ColliderLayer))
                if (JumpSpeed > 0) JumpSpeed = 0;

            if (TestBlock)//如果接触地面
            {
                ifJump = true;//允许跳跃了
                ifButtonJump = false;
                JumpTime = 0;
                if(ifJump)
                    if (JumpSpeed != 0)//让降落速度归零
                        JumpSpeed = 0;
            }
            else//如果当前不在地面/如果当前在空中
            {
                if (JumpSpeed > -0.02f) JumpSpeed -= 0.0006f;
                //如果在没跳跃的情况下进入空中 则不允许跳跃
                if (!Input.GetKey(KeyCode.K) && ifJump) ifJump = false;
            }

            if (ifJump)//是否允许跳跃
            {
                if (Input.GetKey(KeyCode.K))
                {
                    if (!ifButtonJump)
                    {
                        if (JumpTime <= 20)
                        {
                            JumpSpeed = 0.012f;
                            JumpTime++;
                        }
                        else
                        {
                            ifButtonJump = true;
                        }
                    }
                }
                else
                {
                    if(!TestBlock)
                        ifButtonJump = true;
                }
            }
        }
        if(this.GetComponent<Script_PlayerState>().getState_Risk())
        {
            if (!DieJump)
            {
                JumpSpeed = 0.015f;
                DieJump = true;
            }
            if (JumpSpeed > -0.02f) JumpSpeed -= 0.0006f;
        }
        if (!this.GetComponent<Script_PlayerState>().getState_GameStop())
            Player.Translate(0, JumpSpeed, 0);
    }
    //获取
    public float getStart_JumpSpeed()//返回玩家是否在空中的状态
    {
        return JumpSpeed;
    }
    public bool getStart_ifMove()
    {
        return ifMove;
    }
    public bool getStart_Float()
    {
        return !TestBlock;
    }
}
