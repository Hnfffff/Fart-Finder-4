using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text interactText; //variable for the interact text
    public TMP_Text oxygenText; //variable for the oxygen text
    public TMP_Text sanityText; //variable for the sanity text

    public float sanity = 100f; //set the base sanity value as a float
    public float oxygen = 100f; //set the base oxygen value as a float

    [SerializeField]
    private List<string> farts = new List<string> { "fatass bandaid to get the script to work"};

    public List<string> unusedSpawns = new List<string>();
    public List<string> usedSpawns = new List<string>();

    private int Multiplier;


    public AudioSource breathing;
    // Start is called before the first frame update
    void Start()
    {
        interactText.text = ""; //set the interact text to '' (so pretty much nothing)
        breathing.loop = true; // make the breathing audio loop
        breathing.Play(); //play the breathing audio

        StartCoroutine(LowerOxygen()); //start the lower oxygen loop
        StartCoroutine(LowerSanity()); //start the lowersanity loop
    }

    public void Addlist(string item)
    {
        farts.Add(item);
    }

    public void Removelist(string item)
    {
        farts.Remove(item);
    }

    public int GetListLength() 
    {
        return farts.Count;
    }

    public string GetIndex(int index)
    {
        return farts[index];
    }



    IEnumerator LowerOxygen()
    {
        oxygenText.text = $"Oxygen: {oxygen}%"; //set oxygen text to an 'f' string ( idk what its called in c# but they are called that in python)
        yield return new WaitForSeconds(3); //wait 3 seconds
        oxygen -= 1; //lower oxygen by 1
        StartCoroutine(LowerOxygen()); //start the loop again baby to make it infinite
    }

    IEnumerator LowerSanity()
    {
        sanityText.text = $"Sanity: {sanity}%"; //same as above but for the sanity
        yield return new WaitForSeconds(5); //waits five seconds
        sanity -= 1;
        StartCoroutine(LowerSanity());
    }

    IEnumerator SpawnFart()
    {
        yield return new WaitForSeconds(Random.Range(1, 40) * Multiplier);
    }

}
