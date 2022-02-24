using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderFish : AFish
{
    override protected void FixedUpdate() {
        base.FixedUpdate();
    }

    public override void InitFish(float _boxRadius)
    {
        base.InitFish(_boxRadius);
        //fishData.m_speed = Random.Range(4f,4.5f);
        fishData.m_speed = 4f;
    }

}
