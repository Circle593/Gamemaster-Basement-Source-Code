using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject fadeScreenIn;
    public GameObject textbox;
    public string toSay;

    void Start()
    {
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
        
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        fadeScreenIn.SetActive(false);
        textbox.GetComponent<Text>().text = toSay;
        yield return new WaitForSeconds(2);
        textbox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }

}
