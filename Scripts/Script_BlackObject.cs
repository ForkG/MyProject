using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_BlackObject : MonoBehaviour
{
    public bool ifEnd;//正放结尾
    public bool ifEnd_2;//倒放结尾

    public bool ifPlay;

    Animator animator;

    int time;

    public void LoadObject()//切换场景时被调用的，用于加载新场景里必要的对象
    {
        
    }

    void Start()
    {
        ifEnd = false;
        ifPlay = false;
        time = 0;
        animator = this.GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    void Update()
    {
        animator.SetBool("ifPlay", ifPlay);
        if (ifPlay)//表示动画开始播放
        {
            switch (getAnimationState())
            {
                case 1://黑幕完全闭合
                    animator.SetFloat("Speed", 0);
                    animator.SetBool("ifEnd_2", false);
                    if (time < 40)
                    {//等待一段时间后再开始播放动画
                        time++;
                    }
                    else
                    {
                        animator.SetBool("ifEnd", true);
                        animator.SetFloat("Speed", 1);
                    }
                    break;
                case 2://黑幕完全撤开
                    animator.SetBool("ifEnd", false);
                    animator.SetBool("ifEnd_2", true);
                    ifPlay = false;
                    break;
            }
        }else if(time > 0)
        {
            gameObject.SetActive(false);
        }

    }

    public void PlayAnimation()//用这个函数让黑幕动画开始播放
    {
        if (!ifPlay)
        {
            time = 0;
            ifPlay = true;
            animator.SetFloat("Speed", 1);
        }
    }
    public int getAnimationState()//  不返回0时，表示当前动画正在进行   返回0时，没有动画在进行
    {
        if (!ifPlay)//此时没有在播放动画
            return 0;
        else if (ifEnd)//黑幕只有在完全闭合时，ifEnd是true状态，所以当ifEnd是true时，表示黑幕已经完全闭合了
            return 1;
        else if (ifEnd_2)//如果ifEnd是false，而ifEnd_2是true的状态，则说明黑幕已经完全撤开了
            return 2;
        else//动画在第一阶段或者第二阶段还没播放完
            return 3;
    }
}
