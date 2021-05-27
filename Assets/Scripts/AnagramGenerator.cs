using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic.Dictionary;

public static class ShuffleClass {
    private static System.Random rng = new System.Random();  

    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}


public class AnagramGenerator
{
    // Start is called before the first frame update
    
    public List<List<string>> levels = new List<List<string>>();
    public List<string> finalWords = new List<string>();
    public List<string> finalPages = new List<string>();
    public List<bool> npcTypes = new List<bool>();
    private static System.Random rng = new System.Random();

    List<string> level1 = new List<string>();
    List<string> level2 = new List<string>();
    List<string> level3 = new List<string>();
    List<string> level4 = new List<string>();
    List<string> level5 = new List<string>();
    List<string> level6 = new List<string>();
    List<string> level7 = new List<string>();
    List<string> level8 = new List<string>();
    List<string> level9 = new List<string>();
    List<string> level10 = new List<string>();
    List<string> level11 = new List<string>();
    List<string> level12 = new List<string>();
    List<string> level13 = new List<string>();
    List<string> level14 = new List<string>();
    List<string> level15 = new List<string>();

    public void loadWords(){
        // death
        level1.Add("donuts;boxes");
        level1.Add("eggs;boxes");
        level1.Add("cola;bottles");
        level1.Add("fanta;bottles");
        level1.Add("shampoo;bottles");
        levels.Add(level1);
        finalWords.Add("death");
        npcTypes.Add(true);

        // kill
        level2.Add("kiwis;boxes");
        level2.Add("pizza mix;packs");
        level2.Add("lemonade;boxes");
        level2.Add("milk;bottles");
        levels.Add(level2);
        finalWords.Add("kill");
        npcTypes.Add(true);

        // attack
        level3.Add("pizza;boxes");
        level3.Add("tea;boxes");
        level3.Add("water;bottles");
        level3.Add("apples;bags");
        level3.Add("popcorn;packs");
        level3.Add("milk;bottles");
        levels.Add(level3);
        finalWords.Add("attack");
        npcTypes.Add(true);

        // heal
        level4.Add("shampoo;bottles");
        level4.Add("bread;bags");
        level4.Add("oranges;bags");
        level4.Add("lemonade;bottles");
        levels.Add(level4);
        finalWords.Add("heal");
        npcTypes.Add(false);

        // love
        level5.Add("cereal;boxes");
        level5.Add("popcorn;packs");
        level5.Add("gravy;packs");
        level5.Add("waffle mix;packs");
        levels.Add(level5);
        finalWords.Add("love");
        npcTypes.Add(false);

        // food
        level6.Add("flour;bags");
        level6.Add("oranges;bags");
        level6.Add("antibiotic;bottles");
        level6.Add("bread;bags");
        levels.Add(level6);
        finalWords.Add("food");
        npcTypes.Add(false);

        // pistol
        level7.Add("syrup;bottles");
        level7.Add("milk;bottles");
        level7.Add("apples;bags");
        level7.Add("water;bottles");
        level7.Add("tomatoes;bags");
        level7.Add("lemonade;bottles");
        levels.Add(level7);
        finalWords.Add("pistol");
        npcTypes.Add(true);

        // vodka
        level8.Add("gravy;packs");
        level8.Add("cola;bottles");
        level8.Add("doughnuts;boxes");
        level8.Add("cakes;packs");
        level8.Add("antibiotic;bottles");
        levels.Add(level8);
        finalWords.Add("vodka");
        npcTypes.Add(true);

        // fruit
        level9.Add("fanta;bottles");
        level9.Add("water;bottles");
        level9.Add("syrup;bottles");
        level9.Add("juice;bottles");
        level9.Add("yogurt;bottles");
        levels.Add(level9);
        finalWords.Add("fruit");
        npcTypes.Add(false);

        // wasted
        level10.Add("wine;bottles");
        level10.Add("tortillas;bags");
        level10.Add("fishes;bags");
        level10.Add("tomatoes;bags");
        level10.Add("waffles mix;packs");
        level10.Add("doughnuts;boxes");
        levels.Add(level10);
        finalWords.Add("wasted");
        npcTypes.Add(true);

        // damage
        level11.Add("bread;bags");
        level11.Add("apples;bags");
        level11.Add("tomatoes;bags");
        level11.Add("peanuts;boxes");
        level11.Add("grapes;bags");
        level11.Add("cakes;packs");
        levels.Add(level11);
        finalWords.Add("damage");
        npcTypes.Add(true);

        // romantic
        level12.Add("yogurt;bottles");
        level12.Add("doughnuts;boxes");
        level12.Add("lemonade;bottles");
        level12.Add("potatoes;bags");
        level12.Add("popcorn;packs");
        level12.Add("fanta;bottles");
        level12.Add("juice;bottles");
        level12.Add("cookies;boxes");
        levels.Add(level12);
        finalWords.Add("romantic");
        npcTypes.Add(false);

        // assassin
        level13.Add("cola;bottles");
        level13.Add("fishes;bags");
        level13.Add("sugar;bags");
        level13.Add("pizza;boxes");
        level13.Add("shampoo;bottles");
        level13.Add("potatoes;bags");
        level13.Add("milk;bottles");
        level13.Add("wine;bottles");
        levels.Add(level13);
        finalWords.Add("assassin");
        npcTypes.Add(true);

        // healthy
        level14.Add("shampoo;bottles");
        level14.Add("eggs;boxes");
        level14.Add("cereal;boxes");
        level14.Add("apples;bags");
        level14.Add("yogurt;bottles");
        level14.Add("doughnuts;boxes");
        level14.Add("gravy;packs");
        levels.Add(level14);
        finalWords.Add("healthy");
        npcTypes.Add(false);

        // murdering
        level15.Add("milk;bottles");
        level15.Add("juice;bottles");
        level15.Add("syrup;bottles");
        level15.Add("doughnuts;boxes");
        level15.Add("meat;bags");
        level15.Add("sugar;bags");
        level15.Add("fishes;bags");
        level15.Add("peanuts;boxes");
        level15.Add("eggs;boxes");
        levels.Add(level15);
        finalWords.Add("murdering");
        npcTypes.Add(true); 

        int indexx = 0;
        foreach (List<string> anagram in levels) {
            finalPages.Add(generatePageProducts(anagram, finalWords[indexx]));
            indexx++;
        }

        /*

        level12.Add("cookies;boxes");
        level11.Add("milk;boxes");
        level11.Add("cereal;boxes");
        level11.Add("eggs;boxes");
        level11.Add("tea;boxes");
        level11.Add("pizza;boxes");
        level11.Add("peanuts;boxes");
        level11.Add("doughnuts;boxes");

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
        listWords.Add("yogurt;bottles");

        listWords.Add("bread;bags");
        listWords.Add("grapes;bags");
        listWords.Add("tortillas;bags");
        listWords.Add("flour;bags");
        listWords.Add("potatoes;bags");
        listWords.Add("meat;bags");
        listWords.Add("fishes;bags");
        listWords.Add("apples;bags");
        listWords.Add("oranges;bags");
        listWords.Add("pasta;bags");
        listWords.Add("tomatoes;bags");
        listWords.Add("sugar;bags");

        listWords.Add("jam;packs");
        listWords.Add("cakes;packs");
        listWords.Add("gravy;packs");
        listWords.Add("turkey;packs");
        listWords.Add("popcorn;packs");
        listWords.Add("waffles mix;packs");
*/
    }

    
    string generatePageProducts(List<string> listWords, string pWord){
        string finalPage = "";
        char[] letters = ToCharArray(pWord);
        int index = 0;
        List<string> listTemp = new List<string>();
        for(index = 0; index < listWords.Count; index++) {
            listWords[index] = listWords[index].Replace(System.Char.ToString(letters[index]), "<b>" + System.Char.ToString(letters[index]) + "</b>");
            string[] subWord = listWords[index].Split(';');
            listTemp.Add(Random.Range(0, 10) + " " + subWord[1] + " of " + subWord[0] + ".\n");
        }
        // Randomize list
        listTemp.Shuffle();

        foreach(string phrase in listTemp){
            finalPage = finalPage + phrase;
        }

        return finalPage;
    }

    static char[] ToCharArray(string Source)
    {
        char[] CharArray = Source.ToLower().ToCharArray();
        //Array.Sort(CharArray);
        return CharArray;
    }

}
