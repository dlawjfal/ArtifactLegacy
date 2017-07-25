using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public GameObject gWallL;
    public GameObject gWallR;
    public GameObject gOutline;

    public GameObject gCharacter;
    //public GameObject gCharacter02;
    public GameObject gMonster;

    // Init
    public void Awake ()
    {
        gCharacter.GetComponent<Character>().Init();
        //gCharacter02.GetComponent<CharGahui>().Init();
        gMonster.GetComponent<Monster>().Init();

        gCharacter.GetComponent<Character>().SetMonster(gMonster);
        //gCharacter02.GetComponent<CharGahui>().SetMonster(gMonster);
        gMonster.GetComponent<Monster>().SetCharacter(gCharacter);
	}
}
