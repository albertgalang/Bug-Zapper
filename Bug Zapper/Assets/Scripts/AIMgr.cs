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
        
    }

    void Update()
    {
        //foreach (var enemy in EntityMgr.inst.enemies)
        //{
        //    if (enemy.GetComponentInParent<UnitAI>().commands.Count == 0)
        //        HandleIntercept(EntityMgr.inst.Player, enemy);
        //}
    }


    public void HandleIntercept(Player entToIntercept, Enemy enemy)
    {
        Intercept intercept = new Intercept(enemy, entToIntercept);
        UnitAI uai = enemy.GetComponent<UnitAI>();
        uai.AddCommand(intercept);
    }
}
