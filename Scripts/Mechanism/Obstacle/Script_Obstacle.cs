using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Obstacle : MonoBehaviour
{
    public GameObject Mechanism;
    public Sprite[] sprite;

    void Update()
    {
        if (Mechanism.GetComponent<Script_ObstacleMechansm>().getState())
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = sprite[1];
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = sprite[0];
        }
    }
}
