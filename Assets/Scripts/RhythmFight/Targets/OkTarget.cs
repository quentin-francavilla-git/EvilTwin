using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkTarget : ITarget
{
    public override void Action() {
        base.Action();
        fightManager.HitEnemy();
    }
}
