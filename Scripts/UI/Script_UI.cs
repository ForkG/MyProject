using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_UI : MonoBehaviour
{
    public GameObject UI_StopFrame;
    GameObject SystemObject;

    void Start()
    {
        UI_StopFrame.SetActive(false);
    }

    public void LoadObject()
    {
        SystemObject = GameObject.Find("GameSystem");
    }

    public void OnStop()
    {
        if(SystemObject.GetComponent<Script_SystemObject>().GameStop == false && SystemObject.GetComponent<Script_SystemObject>().getBlackAnimationState() == 0)
        {
            Time.timeScale = 0;
            UI_StopFrame.SetActive(true);
            SystemObject.GetComponent<Script_SystemObject>().GameStop = true;
        }
    }
    public void OnContinue()
    {
        if (SystemObject.GetComponent<Script_SystemObject>().GameStop == true)
        {
            Time.timeScale = 1;
            UI_StopFrame.SetActive(false);
            SystemObject.GetComponent<Script_SystemObject>().GameStop = false;
        }
    }

    public void OnAgain()
    {
        if(SystemObject.GetComponent<Script_SystemObject>().GameStop == true)
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();
            this.GetComponent<Script_BaseObjects>().nextScene(scene.name);
            this.GetComponent<Script_BaseObjects>().setBrith(new Vector2(0,0));
            UI_StopFrame.SetActive(false);
        }
    }

    //[System.Obsolete]
    public void OnHome()
    {
        if (SystemObject.GetComponent<Script_SystemObject>().GameStop == true)
        {
            Time.timeScale = 1;
            this.GetComponent<Script_BaseObjects>().nextScene("ChoiceScene");
            this.GetComponent<Script_BaseObjects>().setBrith(new Vector2(0, 0));
            this.GetComponent<Script_BaseObjects>().DeleteDieNumber();
            UI_StopFrame.SetActive(false);
        }
    }
}
