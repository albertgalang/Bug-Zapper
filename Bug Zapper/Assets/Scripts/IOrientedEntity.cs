using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrientedEntity
{
    [SerializeField]
    Vector3 Velocity { get; set; }

    [SerializeField]
    float Speed { get; set; }
    [SerializeField]
    float DesiredSpeed { get; set; }


    [SerializeField]
    float Acceleration { get; set; }
    [SerializeField]
    float MinSpeed { get; set; }
    [SerializeField]
    float MaxSpeed { get; set; }
}
