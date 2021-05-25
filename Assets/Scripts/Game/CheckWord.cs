using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTransfer : MonoBehaviour
{
    string word;
    public GameObject inputField;
    public GameObject pageSheet;


    // Check if the word in the inputField is the finalWord
    public bool checkAnswer(string finalWord){
        // Get text
        word = inputField.GetComponent<Text>().text;
        
        // Clean text
        word.Replace(" ","");
        word.Replace("\n","");
        
        if(word == finalWord){
            return true;
        }
        return false;
    }

    public void newAnagram(){
        
    }

}
