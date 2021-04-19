using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    [SerializeField]
    private Vector3 position = Vector3.zero;
    [SerializeField]
    private float speed;

    public Vector3 Position { get => position; set => position = value; }
    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
