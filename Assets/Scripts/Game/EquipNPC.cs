using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipNPC : MonoBehaviour {
    Game game;
    EquipmentManager manager;
    // Use this for initialization

    private void Awake() {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }


    void Start() {
        manager = gameObject.AddComponent(typeof(EquipmentManager)) as EquipmentManager;

        EquipmentManager temp = game.GetNPCEquipment();

        foreach (KeyValuePair<Equipable, Color> item in temp.items) {
            manager.AddItem(item.Key, item.Value);
        }

        manager.materials = temp.materials;
        manager.AddMaterials();
    }

    // Update is called once per frame
    void Update() {

    }
}
