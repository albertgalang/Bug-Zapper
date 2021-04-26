using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public Enemy entity;
    // public bool isRunning = false;
    public Command(Enemy ent)
    {
        entity = ent;
    }


    // Start is called before the first frame update
    public virtual void Init()
    {

    }

    // Update is called once per frame
    public virtual void Tick()
    {

    }

    public virtual bool IsDone()
    {
        return false;
    }

    public virtual void Stop()
    {

    }
}
