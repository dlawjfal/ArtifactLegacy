using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject gCharacter;
    private Vector3 vResetPosition;

    private int iHp;
    private int iAtk;
    private float fSpeed;
    private float fStrikeRange;

    public void Init()
    {
        vResetPosition = new Vector3(0.0f, 8.0f);

        iHp = 100;
        iAtk = 10;
        fSpeed = 1.0f;
        fStrikeRange = 1.0f;
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

        this.GetComponent<Rigidbody2D>().velocity *= fSpeed;
        this.GetComponent<CircleCollider2D>().radius = fStrikeRange / 2.0f;
    }

    // ----- Set -----

    public void SetCharacter(GameObject Character)
    {
        gCharacter = Character;
    }

    public void SetHp(int hp)
    {
        iHp = hp;
    }

    public void SetAtk(int atk)
    {
        iAtk = atk;
    }

    public void SetSpeed(float speed)
    {
        fSpeed = speed;
    }

    public void SetStrikeRange(float strikeRange)
    {
        fStrikeRange = strikeRange;
    }

    // ----- Get -----

    public int GetHp()
    {
        return iHp;
    }

    public int GetAtk()
    {
        return iAtk;
    }

    public float GetSpeed()
    {
        return fSpeed;
    }

    public float GetStrikeRange()
    {
        return fStrikeRange;
    }
}
