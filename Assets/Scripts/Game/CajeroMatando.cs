using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajeroMatando : MonoBehaviour
{
    public Animator animator;
    AudioSource shoot;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shoot = GetComponent<AudioSource>();
        StartCoroutine(Waiting(0.7f));
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }

    private IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        shoot.Play();
    }
}
