using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    private GameObject gMonster;
    private Vector2 vAngle;
    private int iHp;
    private int iAtk;
    private float fDistance;
    private float fCurrentDelay;
    private float fCharge;
    private float fRange;
    private float fPower;
    private float fDelay;
    private float fCritical;
    private bool bCanAttack;
    private bool bCharging;

    public void Init()
    {
        if (gMonster == null)
            Debug.Log("NULL Monster");
        vAngle = Vector2.zero;
        iHp = 100;
        iAtk = 10;
        fDistance = 0.0f;
        fCurrentDelay = 0.0f;
        fCharge = 0.0f;
        fRange = 2.0f;
        fPower = 1000.0f;
        fDelay = 2.0f;
        fCritical = 0.5f;
        bCanAttack = true;
        bCharging = false;
    }

    private void Update()
    {
        if (bCanAttack == false)
        {
            fCurrentDelay += 0.1f;
            if (fCurrentDelay >= fDelay)
            {
                fCurrentDelay = 0.0f;
                bCanAttack = true;
            }
        }

        if (bCharging == true)
        {
            fCharge += 0.1f;
        }
        else if (bCharging == false)
        {
            fCharge = 0.0f;
        }
    }

    private void OnMouseDown()
    {
        bCharging = true;

        if (bCanAttack == false)
            return;

        fDistance = Vector2.Distance(gMonster.GetComponent<Transform>().position, this.GetComponent<Transform>().position);

        if (fDistance <= fRange)
        {
            vAngle = gMonster.GetComponent<Transform>().position - this.GetComponent<Transform>().position;
            vAngle.Normalize();
            gMonster.GetComponent<Transform>().Translate(Vector2.zero);
            gMonster.GetComponent<Rigidbody2D>().AddForce(vAngle * fPower);

            bCanAttack = false;
        }
    }

    private void OnMouseUp()
    {
        bCharging = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fRange);
    }

    // ----- Set -----

    public void SetMonster(GameObject monster)
    {
        gMonster = monster;
    }

    public void SetHp(int hp)
    {
        iHp = hp;
    }

    public void SetAtk(int atk)
    {
        iAtk = atk;
    }

    public void SetRange(float range)
    {
        fRange = range;
    }

    public void SetPower(float power)
    {
        fPower = power;
    }

    public void SetCritical(float critical)
    {
        fCritical = critical;
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

    public float GetRange()
    {
        return fRange;
    }

    public float GetPower()
    {
        return fPower;
    }

    public float GetCritical()
    {
        return fCritical;
    }
}
