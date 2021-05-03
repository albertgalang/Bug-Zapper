using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float InputZ { get => inputZ; }
    public float InputX { get => inputX; }


    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        entity = EntityMgr.inst.Player;
        // anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DAMAGED00"))
            return;
        else
            this.entity.isTakingDamage = false;


        if (Input.GetKey(KeyCode.W))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveForward();
            // anim.Play("RUN00_F");
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveLeft();
            // anim.Play("RUN00_F");
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveBackward();
            // anim.Play("RUN00_F");
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.entity.gameObject.GetComponent<PlayerPhysics>().MoveRight();
            // anim.Play("RUN00_F");
        }

        inputZ = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
        this.anim.SetFloat("inputZ", inputZ);
        this.anim.SetFloat("inputX", inputX);

        this.entity.gameObject.GetComponent<PlayerPhysics>().MovementHeading();


        //RaycastHit hit;
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        //{
        //    var intersectionPoint = hit.point;
        //    //Debug.DrawLine(Vector3.zero, intersectionPoint, Color.yellow, 300);
        //    //Debug.DrawLine(this.entity.Position, Vector3.forward * 800, Color.red, Mathf.Infinity);
        //    this.entity.gameObject.GetComponent<PlayerPhysics>().SetHeading(intersectionPoint);
        //}

        //if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Damage"))
        //    this.entity.isTakingDamage = false;

    }

    [SerializeField]
    public float deltaSpeed = 1;
    [SerializeField]
    public float deltaHeading = 2;

    public void IncreaseSpeed(Enemy ent)
    {
        ent.DesiredSpeed += deltaSpeed;
        ent.DesiredSpeed = Utils.Clamp(ent.DesiredSpeed, ent.MinSpeed, ent.MaxSpeed);
    }

    //public void DecreaseSpeed(Enemy ent)
    //{
    //    ent.DesiredSpeed -= deltaSpeed;
    //    ent.DesiredSpeed = Utils.Clamp(SelectionMgr.inst.selectedEntity.desiredSpeed,
    //                                   SelectionMgr.inst.selectedEntity.minSpeed,
    //                                   SelectionMgr.inst.selectedEntity.maxSpeed);
    //}

    //public void SetHeading(Enemy ent, float heading)
    //{
    //    ent.DesiredHeading = heading;
    //    ent.DesiredHeading = Utils.Clamp360Degrees(ent.DesiredHeading);
    //}

    public void KeepDistance(Enemy ent, Enemy other)
    {

    }

    //public void Moveback(GameObject ent)
    //{

    //}

    public void PlayerTakingDamage()
    {
        this.entity.isTakingDamage = true;
        anim.Play("DAMAGED00");
        var heathBar = GameObject.FindGameObjectWithTag("HealthBar");
        heathBar.GetComponent<Slider>().value -= 25;
    }
}
