using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartSpawnIn : MonoBehaviour
{
    public string name;

    public string location;

    public GameController g;
    public GameObject Gamemanager;


    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = GameObject.Find("GameController");

        g = Gamemanager.GetComponent<GameController>();
        name = gameObject.name;
        g.Addlist(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        g.unusedSpawns.Add(name);
        g.usedSpawns.Remove(name);
        g.Removelist(name);
    }
}
