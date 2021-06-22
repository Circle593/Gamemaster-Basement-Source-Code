using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GlobalHealth : MonoBehaviour
{
    public static int currentHealth = 1;
    public int internalHealth;
    public GameObject player;
    bool dead = false;
    public GameObject Jumpscare;

    // Update is called once per frame
    void Update()
    {
        internalHealth = currentHealth;
        if(internalHealth == 0)
        {
            internalHealth = -1;
            dead = true;
        }
        if(dead == true)
        {
            Debug.Log("Dead lol");
            player.GetComponent<FirstPersonController>().enabled = false;
            Jumpscare.SetActive(true);
            dead = false;
        }
    }
}
