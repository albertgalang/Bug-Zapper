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
        //diff = EntityToIntercept.Position - this.entity.Position;
        //RelativeVelocity = EntityToIntercept.Velocity - this.entity.Velocity;
        //TPrime = Mathf.Abs(diff.sqrMagnitude) / Mathf.Abs(RelativeVelocity.sqrMagnitude);
        //InterceptPosition = EntityToIntercept.Position + EntityToIntercept.Velocity * TPrime;

        //Vector3 path = (InterceptPosition - this.entity.Position);
        //this.heading = Mathf.Atan2(path.x, path.z);
        //ControlMgr.inst.SetHeading(this.entity, heading * Mathf.Rad2Deg);

        if (this.IsDone())
            LockOn();
        // this.entity.DesiredSpeed = 0;
        // else if (this.entity.GetComponent<BoxCollider>().isTrigger == false)
        else
            ControlMgr.inst.IncreaseSpeed(this.entity);

    }

    public Vector3 diff = Vector3.positiveInfinity;
    // public float doneDistanceSqr = 1500;
    public float doneDistanceSqr = 1500;
    public override bool IsDone()
    {
        // diff = this.entity.Position - InterceptPosition;
        diff = EntityMgr.inst.Player.gameObject.transform.position - this.entity.gameObject.transform.position;
        return (diff.sqrMagnitude < doneDistanceSqr);
    }

    public void LockOn()
    {
        this.entity.onTarget = true;
    }

    public override void Stop()
    {

    }
}
