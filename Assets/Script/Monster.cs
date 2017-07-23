using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject gCharacter;

    private int iHp;
    private Vector3 vResetPosition;
    
    public void Init()
    {
        iHp = 100;
        vResetPosition = new Vector3(0.0f, 8.0f);
    }

    private void Update()
    {
        if (iHp <= 0)
        {
            Destroy(this.gameObject);
        }
        
        if(this.GetComponent<Transform>().position.y <= -8.0f)
        {
            this.GetComponent<Transform>().position = vResetPosition;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}

    // ----- Set -----

    public void SetCharacter(GameObject Character)
    {
        gCharacter = Character;
    }
}
