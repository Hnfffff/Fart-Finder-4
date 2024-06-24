using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFart : MonoBehaviour
{
    [SerializeField] private ParticleSystem fartfx;

    public float debugstartlifetime;

    private void Awake()
    {
        fartfx = GetComponent<ParticleSystem>();
        fartfx.startLifetime = Random.RandomRange(0.2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        debugstartlifetime = fartfx.startLifetime;

        if (fartfx.startLifetime <= 0.001)
        {
            //give dna
            Destroy(gameObject);
        }
    }
}
