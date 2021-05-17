using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour {

    [SerializeField] CharacterCreator creator;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform npcSpawn;
    [SerializeField] Transform playerSpawn;
    List<GameObject> NPCs;

    private void Start() {
        NPCs = new List<GameObject>();
        GameEvents.current.OnNPCDestroyed += AddNPC;
        AddNPC();
    }

    public void AddNPC() {
        NPCs.Add(creator.RandomCharacter(npcSpawn));
    }

}
