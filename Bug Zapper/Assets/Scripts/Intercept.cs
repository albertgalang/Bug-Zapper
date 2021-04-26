using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercept : Command
{
    public Player EntityToIntercept;
    public Vector3 InterceptPosition = Vector3.positiveInfinity;
    public Vector3 RelativeVelocity;
    public float TPrime;
    public float heading;

    public Intercept(Enemy ent, Player entToIntercept) : base(ent)
    {
        EntityToIntercept = entToIntercept;
    }

    public override void Init()
    {

    }

    public override void Tick()
    {
        if (this.IsDone())
            this.entity.DesiredSpeed = 0;
        else
            ControlMgr.inst.IncreaseSpeed(this.entity);

    }

    public Vector3 diff = Vector3.positiveInfinity;
    public float doneDistanceSqr = 1500;
    public override bool IsDone()
    {
        diff = EntityMgr.inst.Player.gameObject.transform.position - this.entity.gameObject.transform.position;
        return (diff.sqrMagnitude < doneDistanceSqr);
    }

    public override void Stop()
    {

    }
}
