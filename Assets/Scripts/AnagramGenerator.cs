using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic.Dictionary;

public class AnagramGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    
    List<List<string>> level1 = new List<List<string>>();
    
    List<string> level11 = new List<string>();
    List<string> level12 = new List<string>();
    List<string> level13 = new List<string>();
    List<string> level14 = new List<string>();
    List<string> level15 = new List<string>();

    List<string> level21 = new List<string>();
    List<string> level22 = new List<string>();
    List<string> level23 = new List<string>();
    List<string> level24 = new List<string>();
    List<string> level25 = new List<string>();

    List<string> level31 = new List<string>();
    List<string> level32 = new List<string>();
    List<string> level33 = new List<string>();
    List<string> level34 = new List<string>();
    List<string> level35 = new List<string>();
    public void loadWords(){
        // death
        level11.Add("donuts;boxes");
        level11.Add("eggs;boxes");
        level11.Add("cola;bottles");
        level11.Add("fanta;bottles");
        level11.Add("shampoo;bottles");

        // kill
        level12.Add("lemonade;bottles");
        level12.Add("waffle mix;packs");
        level12.Add("cookies;boxes");
        level12.Add("milk;bottles");

        // attack
        level13.Add("pizza;boxes");
        level13.Add("tea;boxes");
        level13.Add("water;bottles");
        level13.Add("apples;bags");
        level13.Add("popcorn;packs");
        level13.Add("milk;bottles");

        // heal
        level14.Add("shampoo;bottles");
        level14.Add("bread;bags");
        level14.Add("oranges;bags");
        level14.Add("lemonade;bottles");

        /*level11.Add("tea;boxes");
        listWords.Add("water;bottles");
        listWords.Add("apples;bags");
        listWords.Add("popcorn;packs");
        listWords.Add("milk;bottles");

        level12.Add("cookies;boxes");
        level11.Add("milk;boxes");
        level11.Add("cereal;boxes");
        level11.Add("eggs;boxes");
        level11.Add("tea;boxes");
        level11.Add("pizza;boxes");
        

        listWords.Add("wine;bottles");
        listWords.Add("juice;bottles");
        listWords.Add("water;bottles");
        listWords.Add("cola;bottles");
        listWords.Add("antibiotic;bottles");
        listWords.Add("lemonade;bottles");
        listWords.Add("shampoo;bottles");
        listWords.Add("milk;bottles");
        listWords.Add("fanta;bottles");
        listWords.Add("bbq;bottles");
        listWords.Add("syrup;bottles");

        listWords.Add("bread;bags");
        listWords.Add("flour;bags");
        listWords.Add("potatoes;bags");
        listWords.Add("meat;bags");
        listWords.Add("apples;bags");
        listWords.Add("oranges;bags");
        listWords.Add("pasta;bags");
        listWords.Add("tomatoes;bags");
        listWords.Add("sugar;bags");

        listWords.Add("jam;packs");
        listWords.Add("gravy;packs");
        listWords.Add("turkey;packs");
        listWords.Add("popcorn;packs");
        listWords.Add("waffle mix;packs");
*/
    }

    string generatePageProducts(List<string> listWords ){
        string finalPage = "";
        
        foreach(string word in listWords){
            string[] subWord = word.Split(';');
            finalPage = finalPage + Random.Range(0, 10) + " " + subWord[1] + " of " + subWord[0] + "\n";
        }
        return finalPage;
    }

    /*void loadWordsHash(List<string> wordsList){
        //lettersMap = new Dictionary<char, string>();
        foreach(string word in wordsList){
            foreach(char letter in ToCharArray(word)){
                
            }
        }
        
    }
*/
    static char[] ToCharArray(string Source)
    {
        char[] CharArray = Source.ToLower().ToCharArray();
        //Array.Sort(CharArray);
        return CharArray;
    }

    /*public string getAnagram(string word){
        foreach(char letter in ToCharArray(word)){

        }
        return "";
    }
*/
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
    /*public string genAnagram(){
        return "";
    }*/
}
