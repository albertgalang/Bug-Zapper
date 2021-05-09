using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity, IOrientedEntity
{
    [SerializeField]
    private Vector3 position = Vector3.zero;
    [SerializeField]
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float desiredSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    //[SerializeField]
    //private float heading;
    //[SerializeField]
    //private float desiredHeading;
    [SerializeField]
    private float turnRate;
    [SerializeField]
    private bool onMap;
    [SerializeField]
    public bool onTarget = false;
    [SerializeField]
    public bool isDead = false;

    public Vector3 Position { get => position; set => position = value; }
    public Vector3 Velocity { get => velocity; set => velocity = value; }
    public float Speed { get => speed; set => speed = value; }
    public float DesiredSpeed { get => desiredSpeed; set => desiredSpeed = value; }
    public float Acceleration { get => acceleration; set => acceleration = value; }
    public float MinSpeed { get => minSpeed; set => minSpeed = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    //public float Heading { get => heading; set => heading = value; }
    //public float DesiredHeading { get => desiredHeading; set => desiredHeading = value; }
    public float TurnRate { get => turnRate; set => turnRate = value; }
    public bool OnMap { get => onMap; set => onMap = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
