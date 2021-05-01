using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    [SerializeField]
    private Enemy entity;
    private Vector3 eulerRotation = Vector3.zero;
    private Quaternion enemyQuarternion;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponentInParent<Enemy>();
        enemyQuarternion = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        SetHeading(entity.gameObject.transform.position);

        if (Utils.ApproximatelyEqual(entity.Speed, entity.DesiredSpeed))
        {
            ;
        }
        else if (entity.Speed < entity.DesiredSpeed)
        {
            entity.Speed = entity.Speed + entity.Acceleration * Time.deltaTime;
        }
        else if (entity.Speed > entity.DesiredSpeed)
        {
            entity.Speed = entity.Speed - entity.Acceleration * Time.deltaTime;
        }
        entity.Speed = Utils.Clamp(entity.Speed, 0, entity.MaxSpeed);

        ////heading
        //if (Utils.ApproximatelyEqual(entity.Heading, entity.DesiredHeading))
        //{
        //    ;
        //}
        //else if (Utils.AngleDiffPosNeg(entity.DesiredHeading, entity.Heading) > 0)
        //{
        //    entity.Heading += entity.TurnRate * Time.deltaTime;
        //}
        //else if (Utils.AngleDiffPosNeg(entity.DesiredHeading, entity.Heading) < 0)
        //{
        //    entity.Heading -= entity.TurnRate * Time.deltaTime;
        //}
        //entity.Heading = Utils.Clamp360Degrees(entity.Heading);
        ////
        //var updateVelocity = entity.Velocity;
        //updateVelocity.x = Mathf.Sin(entity.Heading * Mathf.Deg2Rad) * entity.Speed;
        //updateVelocity.y = 0;
        //updateVelocity.z = Mathf.Cos(entity.Heading * Mathf.Deg2Rad) * entity.Speed;
        //entity.Velocity = updateVelocity;

        entity.Position = entity.Position + entity.Velocity * entity.Speed * Time.deltaTime;
        transform.localPosition = entity.Position;

        //eulerRotation.y = entity.Heading;
        //transform.localEulerAngles = eulerRotation;
    }

    public void SetHeading(Vector3 pos)
    {
        // var direction = pos - playerPosition;
        var direction = EntityMgr.inst.Player.gameObject.transform.position - pos;
        entity.Velocity = direction.normalized;
        // direction = cameraCompensate * direction;
        // Debug.DrawLine(this.entity.Position, direction, Color.yellow, 100);
        enemyQuarternion.SetLookRotation(direction);
        enemyQuarternion.x = 0f;
        enemyQuarternion.z = 0f;
        this.entity.gameObject.gameObject.transform.rotation = enemyQuarternion;
    }
}
