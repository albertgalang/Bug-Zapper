using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.Effects;

public class GameMgr : MonoBehaviour
{

    private GameObject destroyMe;

    void Start()
    {
        StartCoroutine(StaleGameObjectCleanUp());
    }

    void Update()
    {
        foreach (var enemy in EntityMgr.inst.enemies)
        {
            if (enemy.isDead)
            {
                EntityMgr.inst.enemies.Remove(enemy);
                destroyMe = enemy.gameObject;
                Destroy(destroyMe);
            }
        }
    }

    private IEnumerator StaleGameObjectCleanUp()
    {
        // stale explosions
        while (true)
        {
            var explosions = GameObject.FindGameObjectWithTag("Explosions").GetComponentsInChildren<ExplosionPhysicsForce>().ToList();
            int half = explosions.Count() / 2;
            foreach (var exp in explosions)
            {
                if (exp == explosions.ElementAt(half)) break;

                Destroy(exp.gameObject);
            }

            var projectiles = GameObject.FindGameObjectWithTag("Projectile").GetComponentsInChildren<Projectile>().ToList();
            half = projectiles.Count() / 2;
            foreach (var proj in projectiles)
            {
                if (proj == projectiles.ElementAt(half)) break;

                Destroy(proj.gameObject);
            }

            yield return new WaitForSeconds(5);
        }

    }
}
