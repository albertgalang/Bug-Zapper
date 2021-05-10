using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.Effects;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{

    private GameObject destroyMe;
    public bool gameEnded = false;

    void Start()
    {
        StartCoroutine(StaleGameObjectCleanUp());
        StartCoroutine(ReviveDeadEnemies());
        StartCoroutine(CollectibleSpawn());
    }

    void Update()
    {
        foreach (var enemy in EntityMgr.inst.enemies)
        {
            if (enemy.isDead)
            {
                // EntityMgr.inst.enemies.Remove(enemy);
                // destroyMe = enemy.gameObject;
                // Destroy(destroyMe);
                enemy.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator CollectibleSpawn()
    {
        var collectible = GameObject.FindGameObjectWithTag("CollectibleFireball");
        while (true)
        {
            if (!collectible.GetComponent<Collectible>().isAlive)
            {
                // collectible.transform.position = new Vector3(Random.Range(-130.0f, 104.0f), 0f, Random.Range(-67.0f, 131.0f));
                collectible.GetComponent<Collectible>().position = new Vector3(Random.Range(-130.0f, 104.0f), 0f, Random.Range(-67.0f, 131.0f));
                collectible.SetActive(true);
            }
            yield return new WaitForSeconds(10);
        }
    }

    private IEnumerator ReviveDeadEnemies()
    {
        while (true)
        {
            foreach (var enemy in EntityMgr.inst.enemies)
            {
                if (enemy.isDead)
                {
                    enemy.isDead = false;
                    enemy.OnMap = false;
                    enemy.Position = new Vector3(2, 0, 433);
                    enemy.transform.position = new Vector3(2, 0, 433);

                    enemy.gameObject.SetActive(true);

                    enemy.GetComponent<UnitAI>().commands.Clear();
                    AIMgr.inst.HandleTeleport(enemy);
                    AIMgr.inst.HandleIntercept(EntityMgr.inst.Player, enemy);
                }
            }
            yield return new WaitForSeconds(3);
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

    public void EndGame(bool winCon)
    {
        if (gameEnded == false && winCon == true)
        {
            gameEnded = true;
            Debug.Log("GAME OVER, YOU'VE WON");
            SceneManager.LoadScene(2);
        }
        else if (gameEnded == false && winCon == false)
        {
            gameEnded = true;
            Debug.Log("GAME OVER, YOU DIED");
            SceneManager.LoadScene(3);
        }
    }
}
