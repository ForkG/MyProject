using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Choice : MonoBehaviour
{
    public GameObject BaseObject;
    bool TransScene;
    string SceneName;

    void Update()
    {
        if (TransScene && BaseObject.GetComponent<Script_BaseObjects>().getBlackAnimationState() == 1)
        {
            SceneManager.LoadSceneAsync(SceneName);
            gameObject.SetActive(false);
            TransScene = false;
            SceneName = "";
        }
    }
    public void OnButton(string n)
    {
        SceneName = n;
        if (!TransScene)
        {
            BaseObject.GetComponent<Script_BaseObjects>().PlayBlackAnimation();
            TransScene = true;
        }
    }
}
