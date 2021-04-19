using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField]
    private Player entity;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = entity.Position;
    }

    // Update is called once per frame
    void Update()
    {
        entity.Position = playerPosition;
        transform.position = entity.Position;
    }

    public void MoveForward()
    {
        playerPosition.z += entity.Speed;
    }
    public void MoveBackward()
    {
        playerPosition.z -= entity.Speed;
    }
    public void MoveLeft()
    {
        playerPosition.x -= entity.Speed;
    }
    public void MoveRight()
    {
        playerPosition.x += entity.Speed;
    }
}
