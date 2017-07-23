using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    List<GameObject> lCharacter;

    public override void Init()
    {
        lCharacter = new List<GameObject>();
    }
}