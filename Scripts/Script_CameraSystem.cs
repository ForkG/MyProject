using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CameraSystem : MonoBehaviour
{
    Transform Player;//玩家
    float MoveSpeed;//镜头跟随玩家的速度

    Transform Camera;//镜头
    int FloatTime;//记录玩家悬空时间
    float MoveX;
    float MoveY;

    public void LoadObject()
    {
        Player = GameObject.Find("Player").transform;
    }
    void Start()
    {
        Camera = this.transform;
        MoveSpeed = 0.2f;
    }
    void Update()
    {
        if (Player != null)
        {
            MoveX = Player.position.x - Camera.position.x;
            MoveY = Player.position.y - Camera.position.y + 0.2f;

            if (Player.GetComponent<Script_PlayerState>().getState_Risk() == false)
            {
                if (Player.GetComponent<Script_PlayerControl>().getStart_JumpSpeed() <= -0.02f)
                    FloatTime++;
                else
                    FloatTime = 0;

                if (FloatTime < 30)
                    Camera.Translate(new Vector2(MoveX, MoveY * MoveSpeed));
                else
                    Camera.Translate(new Vector2(MoveX, (MoveY - 0.2f) * MoveSpeed));
            }
        }
    }
}
