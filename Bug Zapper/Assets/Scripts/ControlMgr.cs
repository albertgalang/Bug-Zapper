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
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveForward();
            anim.Play("RUN00_F");
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveLeft();
            anim.Play("RUN00_F");
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveBackward();
            anim.Play("RUN00_F");
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveRight();
            anim.Play("RUN00_F");
        }
    }
}
