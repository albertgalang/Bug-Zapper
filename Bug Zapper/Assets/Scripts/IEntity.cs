using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    [SerializeField]
    Vector3 Position { get; set; }
    [SerializeField]
    Vector3 Velocity { get; set; }
    [SerializeField]
    float Speed { get; set; }
}
