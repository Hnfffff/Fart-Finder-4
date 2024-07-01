using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text interactText; //variable for the interact text
    //public TMP_Text oxygenText; //variable for the oxygen text
    //public TMP_Text sanityText; //variable for the sanity text

    public Image sanityImage;
    public Image oxygenImage;

    public Sprite goodSprite;
    public Sprite midSprite;
    public Sprite badSprite;

    public float sanity = 100f; //set the base sanity value as a float
    public float oxygen = 100f; //set the base oxygen value as a float

    [SerializeField]
    private List<string> farts = new List<string> { "fatass bandaid to get the script to work"};

    public GameObject Prefab;

    public int spawnIdex;
    public List<string> unusedSpawns = new List<string>();
    public List<string> usedSpawns = new List<string>();
    public GameObject spawnlocation;

    private int Multiplier = 1;


    public AudioSource breathing;
    // Start is called before the first frame update
    void Start()
    {
        unusedSpawns = new List<string> (new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

        interactText.text = ""; //set the interact text to '' (so pretty much nothing)
        breathing.loop = true; // make the breathing audio loop
        breathing.Play(); //play the breathing audio

        StartCoroutine(LowerOxygen()); //start the lower oxygen loop
        StartCoroutine(LowerSanity()); //start the lowersanity loop

        StartCoroutine(SpawnFart());

        sanityImage.sprite = goodSprite;
        oxygenImage.sprite = goodSprite;
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
        //oxygenText.text = $"Oxygen: {oxygen}%"; //set oxygen text to an 'f' string ( idk what its called in c# but they are called that in python)
        yield return new WaitForSeconds(3); //wait 3 seconds
        oxygen -= 1; //lower oxygen by 1
        StartCoroutine(LowerOxygen()); //start the loop again baby to make it infinite
        
        if(oxygen >= 66 && oxygen <= 100)
        {
            oxygenImage.sprite = goodSprite;
        }
        else if(oxygen >= 33 && oxygen < 66)
        {
            oxygenImage.sprite= midSprite;
        }
        else if (oxygen >= 0 && oxygen < 33)
        {
            oxygenImage.sprite = badSprite;
        }
    }

    IEnumerator LowerSanity()
    {
        //sanityText.text = $"Sanity: {sanity}%"; //same as above but for the sanity
        yield return new WaitForSeconds(5); //waits five seconds
        sanity -= 1;
        StartCoroutine(LowerSanity());

        if (sanity >= 66 && sanity <= 100)
        {
            sanityImage.sprite = goodSprite;
        }
        else if (sanity >= 33 && sanity < 66)
        {
            sanityImage.sprite = midSprite;
        }
        else if (sanity >= 0 && sanity < 33)
        {
            sanityImage.sprite = badSprite;
        }
    }

    IEnumerator SpawnFart()
    {
        yield return new WaitForSeconds(Random.Range(1, 40) * Multiplier);
        if(unusedSpawns.Count != 0)
        {
            spawnIdex = Random.Range(0, unusedSpawns.Count);
            foreach(string s in unusedSpawns)
            {
                if( s == spawnIdex.ToString())
                {
                    spawnlocation = GameObject.Find(s);
                    var tempfart = Instantiate(Prefab, spawnlocation.transform.position, Quaternion.identity);
                    tempfart.name = s;
                    unusedSpawns.Remove(s);
                    usedSpawns.Add(s);
                    break;
                }
            }
        }
        StartCoroutine(SpawnFart());
    }

}
