using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimController : MonoBehaviour
{
    public Animator Animator; //variable holds the animator
    //private Animation fingerAnimator;
    //private GameObject Finger;

    Helditems itemcontrol; //inventory script
    FartSucker fartSucker;


    // Start is called before the first frame update
    void Start()
    {
        itemcontrol =GetComponent<Helditems>(); //gets the inventory script from the player and assigns it to itemcontrol
        Animator = GetComponent<Animator>(); //gets the animator component
        //fingerAnimator = Finger.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) //if the identifier from the 'inventory' script is equal to 'sucker' and the left mouse button is down
        //{

        // if(itemcontrol.activeitem == "sucker")
        //{
        //Animator.Play("Base Layer.Sucking"); //play the sucking animation
        // }

        // }

        if (Input.GetMouseButton(0)) //if left mouse button is down
        {
            if (itemcontrol.activeitem == "detector") // if the identifier from the 'inventory' script is equal to 'detector'
            {
                Animator.Play("Base Layer.ButtonPress"); //play click animation
            }

            if(itemcontrol.activeitem == "sucker") //if the identifier from 'inventory' script is equal to 'sucker'
            {
                Animator.Play("Base Layer.Sucking"); //play the sucking animation
            }
        }

    }
}
