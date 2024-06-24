using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class LoadItem : MonoBehaviour
{
    public Renderer render;

    public Material loadingBar;

    public AudioSource loadingSound;

    public AudioClip loadingSFX;
    public AudioClip doneSFX;

    public GameObject player;
    public float barPercent;

    public bool isLoading;

    public TMP_Text interactText;


    // Start is called before the first frame update
    void Start()
    {
        loadingSound.clip = loadingSFX;
        render = GetComponent<Renderer>();
        isLoading = false;
        loadingBar.SetFloat("_Progress", 0.72f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLoading && Vector3.Distance(player.transform.position, transform.position) < 2f)
        {
            interactText.text = "Press 'E' to Extract DNA";
        }
        else
        {
            interactText.text = "";
        }

        if(Input.GetKeyDown(KeyCode.E) && Vector3.Distance(player.transform.position, transform.position) < 2f && !isLoading)
        {
            loadingSound.clip = loadingSFX;
            loadingSound.Play();
            StartCoroutine(Loading());
        }
    }

    IEnumerator Loading()
    {
        isLoading = true;
        barPercent = 0.72f;

        while(barPercent > 0.65f)
        {
            loadingBar.SetFloat("_Progress", barPercent);
            yield return new WaitForSeconds(1);
            barPercent -= 0.00411764705882f;
        }

        loadingSound.clip = doneSFX;
        loadingSound.Play();
        yield return new WaitForSeconds(0.5f);
        loadingBar.SetFloat("_Progress", 0.72f);
        isLoading = false;
    }
}
