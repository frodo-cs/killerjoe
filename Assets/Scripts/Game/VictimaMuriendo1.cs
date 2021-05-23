using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictimaMuriendo1 : MonoBehaviour
{
    public Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(Waiting(0.7f));
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    //wait for 2 seconds
    private IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("Muriendo", true);
    }


}
