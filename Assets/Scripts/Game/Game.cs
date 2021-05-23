using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour {

    [SerializeField] CharacterCreator creator;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform npcSpawn;
    [SerializeField] Transform playerSpawn;

    private void Start() {
        GameEvents.current.OnNPCDestroyed += AddNPC;
        Cursor.visible = false;
        AddNPC();
    }

    public void AddNPC() {
        creator.RandomCharacter(npcSpawn);
    }

}
