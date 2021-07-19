using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Script_Artilley : MonoBehaviour
{
    public GameObject AttackObject;
    public Transform AttackPosition;
    public bool ifAttack;
    public bool Attack;

    Animator animator;
    public int AttackTime;//隔多少秒攻击/攻击间隔时间
    int attackTime;
   
    void Start()
    {
        animator = this.GetComponent<Animator>();
        ifAttack = true;
    }
    void Update()
    {
        animator.SetBool("Attack", Attack);
    }
    void FixedUpdate()
    {
        if (attackTime < AttackTime)
        {
            if (!Attack)
                attackTime++;
        }
        else if(ifAttack)
        {
            CreateAttackObject();
            Attack = true;
            attackTime = 0;
        }
    }

    void CreateAttackObject()
    {
        ifAttack = false;
        AttackObject.SetActive(true);
        AttackObject.GetComponent<Script_ArtilleyAttack>().setAttack(AttackPosition.position);
    }
}
