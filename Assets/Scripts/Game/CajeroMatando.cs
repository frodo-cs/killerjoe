using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajeroMatando : MonoBehaviour
{
    public Animator animator;
    AudioSource shoot;
    [SerializeField] float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shoot = GetComponent<AudioSource>();
        StartCoroutine(Waiting(time));
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
