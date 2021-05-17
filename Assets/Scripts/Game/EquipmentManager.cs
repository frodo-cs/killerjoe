using System;
using System.Linq;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    [SerializeField] MeshManager meshManager;

    private void Awake() {
        meshManager = GetComponent<MeshManager>();
    }

    public void AddItem(Equipable item) {
        meshManager.AddMesh(item);
    }

    public void AddItem(Equipable item, Color color) {
        meshManager.AddMesh(item, color);
    }

    public void RemoveItem(Equipable item) {
        meshManager.RemoveMesh(item.Type.ToString());
    }

    public void RemoveAll() {
        foreach(ItemType type in Enum.GetValues(typeof(ItemType)).Cast<ItemType>()) {
            meshManager.RemoveMesh(type.ToString());
        }
    }
}
