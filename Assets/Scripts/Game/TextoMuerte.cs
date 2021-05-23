using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoMuerte : MonoBehaviour
{
    [SerializeField] GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        StartCoroutine(Waiting(2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //wait for 2 seconds
    private IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        text.SetActive(true);
    }
}
