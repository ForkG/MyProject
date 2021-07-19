using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Initial : MonoBehaviour
{
    public GameObject BaseObject;
    public GameObject ChoiceObject;
    bool TransScene;

    private void Update()
    {
        if (TransScene && BaseObject.GetComponent<Script_BaseObjects>().getBlackAnimationState() == 1)
        {
            SceneManager.LoadSceneAsync("ChoiceScene");
            gameObject.SetActive(false);
            ChoiceObject.SetActive(true);
        }
    }
    public void OnButton()
    {
        if (!TransScene)
        {
            BaseObject.GetComponent<Script_BaseObjects>().PlayBlackAnimation();
            TransScene = true;
        }
    }
}
