using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    [SerializeField]
    private Player entity;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    public float deltaSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        entity = EntityMgr.inst.Player;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("pressed W");
            this.entity.DesiredSpeed += deltaSpeed;
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveForward();
            anim.Play("RUN00_F");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("pressed A");
            this.entity.DesiredSpeed += deltaSpeed;
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveLeft();
            anim.Play("RUN00_F");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("pressed S");
            this.entity.DesiredSpeed += deltaSpeed;
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveBackward();
            anim.Play("RUN00_F");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("pressed D");
            this.entity.DesiredSpeed += deltaSpeed;
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveRight();
            anim.Play("RUN00_F");
        }
        else
        {
            this.entity.DesiredSpeed = this.entity.MinSpeed;
            this.entity.gameObject.GetComponent<PlayerPhysics>().StopMove();
        }
    }
}
