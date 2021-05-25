using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    [SerializeField] MeshManager meshManager;
    public List<KeyValuePair<Equipable, Color>> items;
    public Material[] materials;

    private void Awake() {
        items = new List<KeyValuePair<Equipable, Color>>();
        meshManager = GetComponent<MeshManager>();
    }

    public void AddItem(Equipable item) {
        meshManager.AddMesh(item);
    }

    public void AddItem(Equipable item, Color color) {
        items.Add(new KeyValuePair<Equipable, Color>(item, color));
        meshManager.AddMesh(item, color);
    }

    public void AddMaterials() {
        GetComponentInChildren<SkinnedMeshRenderer>().materials = materials;
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
