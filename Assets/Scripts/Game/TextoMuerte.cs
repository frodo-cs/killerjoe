using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextoMuerte : MonoBehaviour
{
    [SerializeField] GameObject text;
   
    AudioSource soundWellDone;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        text.SetActive(false);
        
        soundWellDone = GetComponent<AudioSource>();
        StartCoroutine(Waiting(1.3f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return() {
        Cursor.visible = false;
        SceneManager.LoadScene("Game");
    }

    public void Menu() {
        Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
        SceneManager.LoadScene("Menu");
    }

    //wait for 2 seconds
    private IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        text.SetActive(true);
        soundWellDone.Play();

        
      }
}
