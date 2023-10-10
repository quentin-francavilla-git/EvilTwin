using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedTarget : ITarget
{
    public override void Action() {
        base.Action();
        fightManager.HitPlayer();
    }
}
