using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_UI_Main : MonoBehaviour
{
    //用于控制UI显示样式以及搭配方面的代码
    public GameObject[] UI;
    public GameObject[] BackGround;
    public void setStyle(int n)//设置UI的样式
    {
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(false);
        }
        UI[n].SetActive(true);
    }
    public void setBackGround(int n)//设置背景图片
    {
        for (int i = 0; i < BackGround.Length; i++)
        {
            BackGround[i].SetActive(false);
        }
        BackGround[n].SetActive(true);
    }
}