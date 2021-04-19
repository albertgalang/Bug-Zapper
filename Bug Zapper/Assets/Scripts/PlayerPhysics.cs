using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField]
    private Player entity;
    private Vector3 playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerVelocity = entity.Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (entity.DesiredSpeed > entity.Speed)
        {
            entity.Speed += entity.Acceleration * Time.deltaTime;
        }
        else if (entity.DesiredSpeed < entity.Speed)
        {

            entity.Speed -= entity.Acceleration * Time.deltaTime;
        }
        entity.Speed = entity.Speed.Clamp(entity.MinSpeed, entity.MaxSpeed);


        // heading?


        // position
        entity.Position += entity.Velocity * Time.deltaTime;
        transform.position = entity.Position;
    }

    public void MoveForward()
    {
        playerVelocity.z = Vector3.forward.z * entity.Speed;
        entity.Velocity = playerVelocity;
    }
    public void MoveBackward()
    {
        playerVelocity.z = Vector3.back.z * entity.Speed;
        entity.Velocity = playerVelocity;
    }
    public void MoveLeft()
    {
        playerVelocity.x = Vector3.left.x * entity.Speed;
        entity.Velocity = playerVelocity;
    }
    public void MoveRight()
    {
        playerVelocity.x = Vector3.right.x * entity.Speed;
        entity.Velocity = playerVelocity;
    }
    public void StopMove()
    {
        playerVelocity = Vector3.zero;
        entity.Velocity = Vector3.zero;
    }
}
