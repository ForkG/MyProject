using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ArtilleyAttack : MonoBehaviour
{
    public GameObject Artilley;
    public bool Delete;
    public float Speed;
    float speed;
    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Delete)
        {
            Artilley.GetComponent<Script_Artilley>().ifAttack = true;
            animator.SetBool("Boom", false);
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.down * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            animator.SetBool("Boom", true);
            speed = 0;
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public void setAttack(Vector3 v)
    {
        Delete = false;
        speed = Speed;
        this.GetComponent<CircleCollider2D>().enabled = true;
        transform.position = v;
    }
}
