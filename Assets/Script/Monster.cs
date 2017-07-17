using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    int hp;
    Vector3 resetPosition;

    void Start()
    {
        resetPosition = new Vector3(0.0f, 6.0f);
    }
    
    void Update()
    {
        if (hp <= 0)
        {
            DestroyObject(this);
        }

        if(this.GetComponent<Transform>().position.y >= -6.0f)
        {
            Debug.Log("Out");
            this.GetComponent<Transform>().Translate(resetPosition);
        }
	}
}
