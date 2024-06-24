using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FartDetector : MonoBehaviour
{

    /// <summary>
    /// UNFINISHED UNFINISHED
    /// </summary>


    [SerializeField]
    private GameObject fart; //gameobject for the fart
    private float fartDistance; //float for how far away the fart is from the player

    [SerializeField]
    private AudioSource noFart; //no fart sound/ out of range fart sound
    [SerializeField]
    private AudioSource yesFart; //sound if you are near a fart
    //private object[] obj; //holds objects

    public GameController g;
    public GameObject Gamemanager;

    //public List<string> farts; //list to hold farts



    // Start is called before the first frame update
    void Start()
    {
        g = Gamemanager.GetComponent<GameController>();
        yesFart.pitch = 10f; //set the pitch of the fart noise to 10
    }

    void GetClosestFart() //this will be fun :) the get closest fart function
    {
        //obj = FindSceneObjectsOfType(typeof(GameObject)); //for each item in the scene, find all the gameobjects and add them the object[]

        //foreach (object o in obj) //for each object in the object[] array
        //{
        //GameObject g = (GameObject) o; //convert the object to a gameobject

        //if (g.tag == "Fart") //check if the gameobjects tag is equal to "Fart"
        //{
        //farts.Add(g.name); //if true, add the name of the gameobject to an array
        //}
        //}
        int passes = 0; //how many passes weve been through

        if (g.GetListLength() > 1) //if the length of farts is larger than 1
        {
            Debug.Log(g.GetListLength()); //flag

            int minIndex = 0; //set the min index to 0
            int maxIndex = g.GetListLength() - 1; //max index equals the farts in list -1
            GameObject closest = GameObject.Find(g.GetIndex(minIndex)); //closest gameobject = the gameobject at the minimum index, just as a fallback
            

            while (minIndex <= maxIndex) //while the max index is bigger than or equal to the minmum index
            {
                float x = Vector3.Distance(GameObject.Find(g.GetIndex(minIndex)).transform.position, transform.position); //x is equal to the distance between the player and the fart in the [minIndex] position of the list
                //Debug.Log(x);
                if (passes < 1) //if this is the first pass
                {
                    if (x < Vector3.Distance(GameObject.Find(g.GetIndex(minIndex + 1)).transform.position, transform.position))// if x is smaller than the distance between the fart at [minIndex +1] and the player
                    {
                        closest = GameObject.Find(g.GetIndex(minIndex)); //set closest to be the fart at the min index
                        passes+=1; //make passes increase by 1
                    }

                    passes += 1;
                }
                else //else
                {
                    if (Vector3.Distance(closest.transform.position, transform.position) > x) //if the distance between the current closest fart is larger than x
                    {
                        closest = GameObject.Find(g.GetIndex(minIndex)); //closest is now the fart at [minIndex] index
                        passes+= 1; //make passes go up by 1
                    }

                }

                minIndex+= 1; //make min index go up by one
            }

            fart = closest; //set the fart Gameobject to the closest fart
            //g.farts.Clear(); //empty the list
            passes = 0; //set passes to zero
        }
        else if (g.GetListLength() == 1) //if the length of farts is 1
        {
            fart = GameObject.Find(g.GetIndex(0)); //set fart to the only object in farts
            //g.farts.Clear(); //empty the farts list
        }
        else
        {
            fart = null; //set fart to null
            //g.farts.Clear(); //empty the farts list
        }

    }


    public void TriggerEvent()
    {
        //Debug.Log("this is actually working");

        yesFart.pitch = 10f; //set pitch to 10
        //FindFarts();
        GetClosestFart(); //call GetClosestFart function

        if (fart != null) //if there is a fart
        {
            fartDistance = Vector3.Distance(fart.transform.position, transform.position); //find the distance between the fart and the player
                                                                                          //Debug.Log(fartDistance);

            if (fartDistance < 20) //if the distance is less than 20
            {
                yesFart.pitch -= fartDistance * 0.5f; //make the pitch minus the distance/2
                yesFart.Play();//play the fart found sound
               // g.farts.Clear(); //clear the farts list
            }

            else
            {
                noFart.Play(); //if further than 20 play the no fart sound
               // g.farts.Clear();//empty the farts list
            }

        }
        else
        {
            NoFart(); //run the NoFart function
           // g.farts.Clear(); //empty the farts list
        }
    }

    //void FindFarts()
    //{
        //try
       // {

       // }

       // catch(System.Exception e)
        //{
           // Debug.Log(e);
            //farts.Clear();
       // }

        //foreach(string s in farts)
        //{
            //Debug.Log(s);
        //}
    //}

    void NoFart()
    {
        noFart.Play(); //play the noFart sound
    }

}

