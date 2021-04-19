using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrientedEntity
{
    [SerializeField]
    Vector3 Velocity { get; set; }
}
