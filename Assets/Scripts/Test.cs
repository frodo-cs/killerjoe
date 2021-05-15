using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    [SerializeField] CharacterCreator creator;
    [SerializeField] Transform spawn;

    GameObject c;

    public void CreateCharacter() {
        if (c != null)
            Destroy(c);

        c = creator.RandomCharacter(spawn);
    }
}
