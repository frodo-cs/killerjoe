using System.Collections.Generic;
using UnityEngine;

public class MeshManager : MonoBehaviour {
  
    [SerializeField] Dictionary<string, SkinnedMeshRenderer> currentMeshes;
    private SkinnedMeshRenderer targetMesh;

    private void Awake() {
        targetMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        currentMeshes = new Dictionary<string, SkinnedMeshRenderer>();
        CreateMeshLayers();
    }

    public void AddMesh(Equipable item) {
        SkinnedMeshRenderer newMesh = Instantiate(item.GetComponentInChildren<SkinnedMeshRenderer>());
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[item.Type.ToString()] = newMesh;
    }

    public void AddMesh(Equipable item, Color color) {
        SkinnedMeshRenderer newMesh = Instantiate(item.GetComponentInChildren<SkinnedMeshRenderer>());
        newMesh.transform.parent = targetMesh.transform;
        newMesh.material.color = color;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[item.Type.ToString()] = newMesh;
    }

    public void RemoveMesh(string itemToRemove) {
        if (currentMeshes[itemToRemove] != null)
            Destroy(currentMeshes[itemToRemove].gameObject);
    }

    private void CreateMeshLayers() {
        currentMeshes.Add("Torso", null);
        currentMeshes.Add("Head", null);
    }

}