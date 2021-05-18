using UnityEngine;

public enum ItemType { Head, Torso }

public class Equipable : MonoBehaviour {
    public string Id;
    public ItemType Type;
}
