using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    protected GameObject  gMonster;       // data of Monster now
    protected Vector2     vAngle;         // angle between monster
    protected float       fDistance;      // distance between monster
    protected float       fCurrentDelay;  // attack delay time
    protected float       fCharge;        // charging time
    protected bool        bCanAttack;     // can attack now
    protected bool        bCharging;      // is charging now

    protected int         iHp;            // hp
    protected int         iAtk;           // atk
    protected float       fRange;         // strike range / short = 2, middle = 4, long = 6
    protected float       fPower;         // strike power / short = 1000, middle = 500, long = 10
    protected float       fDelay;         // attack delay
    protected float       fCritical;      // critical rate

    // MonoBehaviour

    protected void Update()
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

    protected void OnMouseDown()
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
            gMonster.GetComponent<Monster>().SetHp()
        }
    }

    protected void OnMouseUp()
    {
        bCharging = false;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fRange);
    }

    // Custom Method

    public void Init()
    {
        gMonster        = null;
        vAngle          = Vector2.zero;
        fDistance       = 0.0f;
        fCurrentDelay   = 0.0f;
        fCharge         = 0.0f;
        bCanAttack      = true;
        bCharging       = false;

        InitData();
    }

    protected virtual void InitData()
    {
        iHp         = 100;
        iAtk        = 10;
        fRange      = 2.0f;
        fPower      = 1000.0f;
        fDelay      = 2.0f;
        fCritical   = 0.5f;
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