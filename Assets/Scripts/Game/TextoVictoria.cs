using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextoVictoria : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject text1;
    AudioSource soundWellDone;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        text1.SetActive(false);
        soundWellDone = GetComponent<AudioSource>();
        StartCoroutine(Waiting(1.3f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu() {
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        SceneManager.LoadScene("Menu");
    }

    //wait for 2 seconds
    private IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        text.SetActive(true);
        soundWellDone.Play();

        while (true)
        {
            text1.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            text1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
      }
}
