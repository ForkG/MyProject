using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ObstacleMechansm : MonoBehaviour
{
    public bool Mode;
    bool StepOn;
    public bool getState()
    {
        return StepOn;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        {
            if (null != collision)
                if (collision.gameObject.layer == 8)
                {
                    StepOn = true;
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
                else if (Mode)
                {
                    StepOn = false;
                    this.GetComponent<SpriteRenderer>().enabled = true;
                }
        }
    }

}
