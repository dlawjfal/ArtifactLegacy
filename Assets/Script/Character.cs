using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public GameObject pMonster;
    public float fRange;
    public float fPower;

    private float fDistance;
    private float fAngle;
    private Vector2 vAngle;

    void Update()
    {

    }

    void OnMouseDown()
    {
        fDistance = Vector2.Distance(pMonster.GetComponent<Transform>().position, this.GetComponent<Transform>().position);

        if (fDistance <= fRange)
        {
            vAngle = pMonster.GetComponent<Transform>().position - this.GetComponent<Transform>().position;
            vAngle.Normalize();
            pMonster.GetComponent<Transform>().Translate(Vector2.zero);
            pMonster.GetComponent<Rigidbody2D>().AddForce(vAngle * fPower);
        }
    }

    // ----- Set -----

    public void SetMonster(GameObject gMonster)
    {
        pMonster = gMonster;
    }
}
