using System.Collections.Generic;
using UnityEngine;


public class CharacterCreator : MonoBehaviour {

    [SerializeField] GameObject characterPrefab;
    [SerializeField] List<Equipable> head;
    [SerializeField] List<Equipable> torso;
    [SerializeField] List<Material> shirt;
    [SerializeField] List<Material> pants;

    readonly Color32[] skinColor = new Color32[] { 
        new Color32(250, 231, 208, 255),
        new Color32(223, 193, 131, 255),
        new Color32(170, 114, 4, 255),
        new Color32(255, 204, 153, 255),
        new Color32(206, 171, 105, 255),
        new Color32(147, 93, 55, 255),
        new Color32(254, 177, 134, 255),
        new Color32(185, 136, 101, 255),
        new Color32(123, 75, 42, 255)
    };

    public GameObject RandomCharacter(Transform spawn) {
        GameObject c = Instantiate(characterPrefab, spawn.position, spawn.rotation);
        Equipable head = null;
        Equipable torso = null;
        
        if(Random.Range(0, 10) > 2) {
            head = this.head[Random.Range(0, this.head.Count)];
        }

        if (Random.Range(0, 10) > 2) {
            torso = this.torso[Random.Range(0, this.torso.Count)];
        }

        if (torso != null)
            c.GetComponent<EquipmentManager>().AddItem(torso, new Color(GetColor(0, 255), GetColor(0, 255), GetColor(0, 255), 255));

        if(head != null) {
            c.GetComponent<EquipmentManager>().AddItem(head, new Color(GetColor(0, 255), GetColor(0, 255), GetColor(0, 255), 255));
        }

        c.GetComponentInChildren<SkinnedMeshRenderer>().materials = GenerateMaterials(c);

        return c;
    }

    private float GetColor(int min, int max) {
        return Random.Range(min, max) / 255.0f;
    }

    private Material[] GenerateMaterials(GameObject c) {
        Material[] materials = c.GetComponentInChildren<SkinnedMeshRenderer>().materials;
        
        materials[3].color = skinColor[Random.Range(0, skinColor.Length)]; // skin
        materials[2].color = new Color(GetColor(0, 255), GetColor(0, 255), GetColor(0, 255), 255 ); // shoes

        materials[5].color = new Color(GetColor(0, 255), GetColor(0, 255), GetColor(0, 255), 255); // shirt 
        materials[0].color = new Color(GetColor(0, 255), GetColor(0, 255), GetColor(0, 255), 255); // shorts


        materials[1].color = Random.Range(0, 10) > 5 ? materials[3].color : materials[0].color; // long

        materials[4].color = Random.Range(0, 10) > 5 ? materials[3].color : materials[5].color; ; // sleeves


        return materials;
    }

}
