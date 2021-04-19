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
    private float inputZ;
    [SerializeField]
    private float inputX;
    [SerializeField]
    private Vector3 mousePos;

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

        inputZ = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
        this.anim.SetFloat("inputZ", inputZ);
        this.anim.SetFloat("inputX", inputX);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            var intersectionPoint = hit.point;
            //Debug.DrawLine(Vector3.zero, intersectionPoint, Color.yellow, 300);
            //Debug.DrawLine(this.entity.Position, Vector3.forward * 800, Color.red, Mathf.Infinity);
            this.entity.gameObject.GetComponent<PlayerPhysics>().SetHeading(intersectionPoint);
        }

    }
}
