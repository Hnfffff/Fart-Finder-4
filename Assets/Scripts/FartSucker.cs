using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartSucker : MonoBehaviour
{
    [SerializeField]
    private AudioSource suck; //audiosource called suck

    private ParticleSystem suckfx; //particlesystem suckfx
    private ParticleSystem fartfx; //particlesystem fartfx

    [SerializeField]
    private float suckLength = 5f; //how far away you can suck farts from

    public Transform shotPos; //transform for the shoot position
    public Transform shotRot;//transform for the shoot rotation

    public RaycastHit suckHit; //raycast hit that stores the information of what the raycast hits

    public Color fartsuck; //colour for fartsuck
    public Color dust; //colour for dust

    public bool isSucking; //isSucking bool

    public GameObject armsuck; //Gameobject holding the arm

    public bool armsucking; //animation purposes


    [SerializeField] private LayerMask LayerMask; //layer


    // Start is called before the first frame update
    private void OnEnable()//when enabled in game
    {
        suckfx = GetComponent<ParticleSystem>(); //set suckfx to the particle system
        suckfx.Stop(); //stop the particle system from playing
        isSucking = false; //set isSucking to false
        armsucking = false; //set armsucking to false
    }

    private void OnDisable()//when disabled in game
    {
        suckfx.Stop();//stop the sucking particle system
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //if mouse is down but only when it is put down
        {
            suckfx.Play(); //play the fart fx
            suck.loop = true;//set suck looping to true
            suck.Play();//play the suck sound
            armsucking = true; //set armsucking to true
        }

        if(Input.GetMouseButton(0)) //while mouse is down
        {
            Suck(); //run suck function
        }

        if(Input.GetMouseButtonUp(0)) //when mouse is unclicked
        {
            suckfx.Stop(); //stop fartfx
            suck.Stop();//stop playing fart sound
            isSucking = false; //set isSucking to false
            armsucking = false;//set armsucking to false
        }
    }
    private void Suck()
    {

        if (Physics.Raycast(shotPos.position, shotRot.forward, out suckHit, suckLength, LayerMask))//if a raycast hits that is shot from the position of shotpos, shot in the forward direction of shotrot, the information from the raycast is sent to suckHit, shoots only as far as sucklength, and only hits things on the same layer as LayerMask
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * suckHit.distance, Color.red);
            //Debug.Log(suckHit.ToString());
            suckfx.startColor = fartsuck; //set the fartfx colour to fartsuck
            fartfx = suckHit.collider.GetComponent<ParticleSystem>(); //the fartfx is set to the object that is hits particle system
            if(isSucking == false) //if sucking is false
            {
                StartCoroutine(Drain()); //start draining the fart
            }
        }
        else
        {
            //Debug.Log("No hit :("); //flag
            suckfx.startColor = dust; //set the fartfx colour to the dust colour
            isSucking = false;//is sucking is false
        }
    }

    //sucks the fart up and lowers its start lifetime incrementally, eventually making it 0
    IEnumerator Drain() //dunno what this means but this is how you have things work after a certain amount of time
    {
        Debug.Log("starting to suck"); //flag
        isSucking = true;//set issucking to true
        yield return new WaitForSeconds(1f); //wait 1 second
        try //try
        {
            fartfx.startLifetime -= 0.05f; //lower the start lifetime of fartfx by 0.05f
        }
        catch(System.Exception e) //catch the error
        {
            Debug.Log(e);//flag
        }
        isSucking = false;//is sucking false
        Debug.Log("Finished Suck");//flag
    }

}
