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

        entity.Position = entity.Position + entity.Velocity * entity.Speed * Time.deltaTime;
        transform.localPosition = entity.Position;
    }

    public void SetHeading(Vector3 pos)
    {
        var direction = EntityMgr.inst.Player.gameObject.transform.position - pos;
        entity.Velocity = direction.normalized;
        enemyQuarternion.SetLookRotation(direction);
        enemyQuarternion.x = 0f;
        enemyQuarternion.z = 0f;
        this.entity.gameObject.gameObject.transform.rotation = enemyQuarternion;
    }
}
