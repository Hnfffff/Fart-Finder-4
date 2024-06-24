using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helditems : MonoBehaviour
{
    [SerializeField] //Making it show in inspector
    private GameObject fartDetector; //create gameobject variable to hold fart detector
    [SerializeField]
    private GameObject fartSucker; //create gameobject variable to hold fart vacuum

    ArmAnimController armAnimController;

    public string activeitem; //identifier for what item is being held, called from other scripts for animation purposes


    // Start is called before the first frame update
    void Start()
    {
        //this will change once the item dropping and picking up is added
        fartDetector.SetActive(true); //set fart detector to true
        fartSucker.SetActive(false); //set fart sucker to false
        activeitem = "detector"; //set active item to fartdetector cos of how its coded now
        armAnimController = GetComponent<ArmAnimController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")) //if key '1' is pressed
        {
            if(fartDetector.activeSelf == false) // checking if the detector is not active
            {
                armAnimController.Animator.Play("Base Layer.Swap");
                fartSucker.SetActive(false); //set sucker to dalse
                fartDetector.SetActive(true); //set detector to true
                activeitem = "detector"; // set identifier to 'detector'
                Debug.Log(activeitem); //flag for testing

                
            }
        }

        if(Input.GetKeyDown("2")) //if key '2' is pressed
        {
            if(fartSucker.activeSelf == false) //check if the sucker is not active
            {
                armAnimController.Animator.Play("Base Layer.Swap");
                fartDetector.SetActive(false); //set detector to false
                fartSucker.SetActive(true); // set sucker to true
                activeitem = "sucker"; //change identifier to 'sucker'
                Debug.Log(activeitem); // flag for testing

                
            }
        }
    }
}
