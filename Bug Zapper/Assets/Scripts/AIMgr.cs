using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public static AIMgr inst;
    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        // layerMask = 1 << 9; // LayerMask.GetMask("Ocean");
    }

    //public RaycastHit Hit;
    //public int layerMask;
    void Update()
    {
<<<<<<< HEAD
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit, float.MaxValue, layerMask))
        //    {
        //        Debug.DrawLine(Camera.main.transform.position, Hit.point, Color.yellow, 300);
        //        Vector3 pos = Hit.point;
        //        pos.y = 0;
        //        Entity381 ent = FindClosestEntInRadius(pos, clickRadius);

        //        if (ent == null)
        //        {
        //            if (Input.GetKey(KeyCode.LeftAlt))
        //            {
        //                // teleport command
        //                HandleTeleport(pos);
        //            }
        //            else
        //            {
        //                // move command
        //                HandleMove(pos);
        //            }
        //        }
        //        else // ent exist
        //        {
        //            if (Input.GetKey(KeyCode.LeftControl))
        //            {
        //                // entity intercept command
        //                HandleIntercept(ent);
        //            }
        //            else
        //            {
        //                // entity follow command
        //                HandleFollow(ent);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("Right mouse button did not collide with anything.");
        //    }
        //}

        foreach (var enemy in EntityMgr.inst.enemies)
        {
            if (enemy.GetComponentInParent<UnitAI>().commands.Count == 0)
                HandleIntercept(EntityMgr.inst.Player, enemy);
        }
=======
        //foreach (var enemy in EntityMgr.inst.enemies)
        //{
        //    if (enemy.GetComponentInParent<UnitAI>().commands.Count == 0)
        //        HandleIntercept(EntityMgr.inst.Player, enemy);
        //}
>>>>>>> 3222618 (enemy to enemy collision)
    }

    //private void HandleTeleport(Vector3 point)
    //{
    //    Teleport teleport = new Teleport(SelectionMgr.inst.selectedEntity, point);
    //    UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        uai.AddCommand(teleport);
    //    }
    //    else
    //    {
    //        uai.SetCommand(teleport);
    //    }
    //}

    //private void HandleMove(Vector3 point)
    //{
    //    Move move = new Move(SelectionMgr.inst.selectedEntity, point);
    //    UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        uai.AddCommand(move);
    //    }
    //    else
    //    {
    //        uai.SetCommand(move);
    //    }
    //}

    //private void HandleFollow(Entity381 entToFollow)
    //{
    //    Follow follow = new Follow(SelectionMgr.inst.selectedEntity, entToFollow);
    //    UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        uai.AddCommand(follow);
    //    }
    //    else
    //    {
    //        uai.SetCommand(follow);
    //    }
    //}

    public void HandleIntercept(Player entToIntercept, Enemy enemy)
    {
        Intercept intercept = new Intercept(enemy, entToIntercept);
        UnitAI uai = enemy.GetComponent<UnitAI>();
        uai.AddCommand(intercept);
    }

    //public float clickRadius = 10000;
    //private Entity381 FindClosestEntInRadius(Vector3 point, float radiusSquared)
    //{
    //    Entity381 minEnt = null;
    //    float minDistance = float.MaxValue;
    //    foreach (var ent in EntityMgr.inst.entities)
    //    {
    //        float distanceSqr = (ent.position - point).sqrMagnitude;
    //        if (distanceSqr < radiusSquared)
    //        {
    //            if (distanceSqr < minDistance)
    //            {
    //                minDistance = distanceSqr;
    //                minEnt = ent;
    //            }
    //        }
    //    }
    //    return minEnt;
    //}
}
