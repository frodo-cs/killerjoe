using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    [SerializeField] CharacterCreator creator;
    [SerializeField] Transform npcSpawn;
    [SerializeField] GameObject npc;

    private void Awake() {
        DontDestroyOnLoad(gameObject);    
    }

    private void Start() {
        GameEvents.current.OnNPCDestroyed += AddNPC;
        GameEvents.current.OnGameLostTime += GameLostTime;
        Cursor.visible = false;
        AddNPC();
    }

    private void GameLostTime() {
        SceneManager.LoadScene("CajeroPierdeTiempo");
    }

    public void AddNPC() {
        npc = creator.RandomCharacter(npcSpawn);
        npc.transform.SetParent(transform);
    }

    public EquipmentManager GetNPCEquipment() {
        return npc.GetComponent<EquipmentManager>();
    }

}
