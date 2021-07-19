using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerAnimator : MonoBehaviour    //处理玩家动画
{
    Animator animator;
    bool Jump;
    bool Move;
    public bool ifEnd;
    bool endPlay;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (this.GetComponent<Script_PlayerState>().getState_End() == false)
        {
            if (this.GetComponent<Script_PlayerState>().getState_GameStop() == false)
            {
                if (this.GetComponent<Script_PlayerState>().getState_Risk() == false)
                {
                    //移动以及跳跃的动画处理
                    Move = this.GetComponent<Script_PlayerControl>().getStart_ifMove();
                    Jump = this.GetComponent<Script_PlayerControl>().getStart_Float();
                    if (Move)
                        animator.speed = 1;
                    else
                        animator.speed = 0;
                    animator.SetBool("Move", Move);
                    animator.SetBool("Jump", Jump);
                }
                else
                {
                    //死亡后的动画处理
                    animator.SetBool("Jump", true);
                }
            }
            else
            {
                animator.speed = 0;
            }
        }
        else 
        {
            if (!endPlay)
            {
                animator.SetBool("EndPlay", true);
                endPlay = true;
            }
            else
            {
                animator.SetBool("EndPlay", false);
            }

            if (ifEnd)
                animator.speed = 0;
            else
                animator.speed = 1;
        }
        animator.SetBool("End", this.GetComponent<Script_PlayerState>().getState_End());
    }
}
