using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajeroPerdona : MonoBehaviour
{
    public Animator animator;
    AudioSource chiflar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        chiflar = GetComponent<AudioSource>();
        StartCoroutine(Waiting(0.7f));
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }

    private IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chiflar.Play();
    }
}
