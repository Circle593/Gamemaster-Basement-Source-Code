using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCEllOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject ActionDisplay;
    public GameObject Actiontext;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    bool doorOpen = false;

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget; 
    }

    private void OnMouseOver()
    {
        if(theDistance <= 1)
        {
            if (doorOpen == false)
            {
                ActionDisplay.SetActive(true);
                Actiontext.SetActive(true);
            }
            
        }
        if(Input.GetButtonDown("Action"))
        {
            if(theDistance <= 3)
            {
                ActionDisplay.SetActive(false);
                Actiontext.SetActive(false);
                TheDoor.GetComponent<Animator>().enabled = true;
                if(doorOpen == false)
                {
                    CreakSound.Play();
                    doorOpen = true;
                }
                
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        Actiontext.SetActive(false);
    }
}
