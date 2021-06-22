using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartyPants : MonoBehaviour
{
    public float theDistance;
    public GameObject text;
    public GameObject theThing;
    

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (theDistance <= 3)
        {
               text.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }
}
