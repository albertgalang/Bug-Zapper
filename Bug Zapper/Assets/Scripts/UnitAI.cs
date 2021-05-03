using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    public Queue<Command> commands = new Queue<Command>();
    [SerializeField]
    public List<Command> CommandList = new List<Command>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CommandList = commands.ToList();
        if (commands.Count > 0)
        {
            var command = commands.Peek();
            command.Init();
            command.Tick();
            // Debug.Log($"is done: {command.IsDone()}");
            if (command.IsDone()) commands.Dequeue();
        }

        if (this.gameObject.tag == "EnemyEntity")
        {
            if (EntityMgr.inst.IsPositionOutOfBounds(this.GetComponent<Enemy>()))
            {
                this.GetComponent<Enemy>().OnMap = false;
                commands.Clear();
                AIMgr.inst.HandleTeleport(this.GetComponent<Enemy>());
                AIMgr.inst.HandleIntercept(EntityMgr.inst.Player, this.GetComponent<Enemy>());
            }
        }
    }

    // add to queue
    public void AddCommand(Command command)
    {
        commands.Enqueue(command);
    }

    // clear queue and make as first command
    public void SetCommand(Command command)
    {
        commands.Clear();
        commands.Enqueue(command);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.tag == "EnemyEntity" && collision.gameObject.tag == "EnemyEntity")
        {
            // this.GetComponent<Enemy>().DesiredSpeed = 10f;
            this.GetComponent<Enemy>().Speed = 10f;
        }

        if (this.gameObject.tag == "EnemyEntity" && collision.gameObject.tag == "Player")
        {
            ControlMgr.inst.PlayerTakingDamage();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (this.gameObject.tag == "EnemyEntity" && collision.gameObject.tag == "EnemyEntity")
        {

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.gameObject.tag == "EnemyEntity")
        {

        }
    }
}

