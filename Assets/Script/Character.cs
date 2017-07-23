using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public GameObject gMonster;
    public float fRange;
    public float fPower;
    public float fDelay;

    private float fDistance;
    private float fCurrentDelay;
    private bool bCanAttack;
    private Vector2 vAngle;
    
    public void Init()
    {
        fDistance = 0.0f;
        fCurrentDelay = 0.0f;
        bCanAttack = true;
        vAngle = Vector2.zero;
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
    }

    private void OnMouseDown()
    {
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
}
