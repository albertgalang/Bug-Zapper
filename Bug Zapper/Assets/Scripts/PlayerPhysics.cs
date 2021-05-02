using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField]
    private Player entity;
    private Vector3 playerPosition;
    private Quaternion playerQuarternion;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = entity.Position;
        playerQuarternion = new Quaternion();
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
   
    public void SetHeading(Vector3 pos)
    {
        var cameraCompensate = Quaternion.Euler(Camera.main.gameObject.gameObject.transform.rotation.eulerAngles);
        var direction = pos - playerPosition;
        direction = cameraCompensate * direction;
        // Debug.DrawLine(this.entity.Position, direction, Color.yellow, 100);
        playerQuarternion.SetLookRotation(direction);
        playerQuarternion.x = 0f;
        playerQuarternion.z = 0f;
        this.entity.gameObject.transform.rotation = playerQuarternion;
    }

    public void MovementHeading()
    {
        if (ControlMgr.inst.InputX < 0)
        {
            var euler = -Vector3.Angle(new Vector3(0f,0f,1f), new Vector3(ControlMgr.inst.InputX, 0f, ControlMgr.inst.InputZ));
            var myEulerVect = entity.transform.eulerAngles;
            myEulerVect.y = euler;
            entity.transform.eulerAngles = myEulerVect;
        }
        else if (ControlMgr.inst.InputX > 0)
        {
            var euler = Vector3.Angle(new Vector3(0f,0f,1f), new Vector3(ControlMgr.inst.InputX, 0f, ControlMgr.inst.InputZ));
            var myEulerVect = entity.transform.eulerAngles;
            myEulerVect.y = euler;
            entity.transform.eulerAngles = myEulerVect;

        }
        else if (ControlMgr.inst.InputZ < 0)
        {
            var euler = Vector3.Angle(new Vector3(0f,0f,1f), new Vector3(ControlMgr.inst.InputX, 0f, ControlMgr.inst.InputZ));
            var myEulerVect = entity.transform.eulerAngles;
            myEulerVect.y = euler;
            entity.transform.eulerAngles = myEulerVect;
        }
        else if (ControlMgr.inst.InputZ > 0)
        {
            var euler = -Vector3.Angle(new Vector3(0f,0f,1f), new Vector3(ControlMgr.inst.InputX, 0f, ControlMgr.inst.InputZ));
            var myEulerVect = entity.transform.eulerAngles;
            myEulerVect.y = euler;
            entity.transform.eulerAngles = myEulerVect;
        }
    }
    
    //public void GetCurrentHeading()
    //{
    //    var velocity = new Vector3(ControlMgr.inst.InputX, 0f, ControlMgr.inst.InputZ);
    //    velocity *= this.GetComponent<Player>().Speed;

        
    //}
}
