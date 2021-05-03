using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Command
{
    [SerializeField]
    private Vector3 CustomTeleportPosition;

    // screen borders
    private List<float> topBotBorders = new List<float>();
    private List<float> leftRightBorders = new List<float>();

    public Teleport(Enemy ent) : base(ent)
    {
    }

    public override void Init()
    {
        topBotBorders.Add(325f);
        topBotBorders.Add(-80f);
        leftRightBorders.Add(-190f);
        leftRightBorders.Add(190f);
    }

    public override void Tick()
    {
        if (entity.OnMap == false)
        {
            entity.Position = new Vector3(leftRightBorders[Random.Range(0, 2)], 0f, topBotBorders[Random.Range(0, 2)]);
            // entity.transform.position = entity.Position;
            entity.OnMap = true;
            // entity.onTarget = false;
        }
    }

    public override bool IsDone()
    {
        if (entity.OnMap == true)
        {
            entity.onTarget = false;
            entity.Speed = 0;
            entity.Velocity = Vector3.zero;
            return true;
        }
        return false;
    }

    public override void Stop()
    {

    }
}
