using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGahui : Character
{
    protected override void InitData()
    {
        iHp = 100;
        iAtk = 10;
        fRange = 6.0f;
        fPower = 10.0f;
        fDelay = 1.0f;
        fCritical = 0.5f;
    }
}
