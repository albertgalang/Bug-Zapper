using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private List<GameObject> enemyPrefab = new List<GameObject>();
    [SerializeField]
    public List<Enemy> enemies = new List<Enemy>();
    private List<float> topBotBorders = new List<float>();
    private List<float> leftRightBorders = new List<float>();

    private int maxEnemiesOnMap = 4;
    private float secondsBetweenSpawns = 2f;

    public Player Player { get => this.player; }
    //public List<Enemy> Enemies { get => this.enemies; }

    //list of bug enemies
    //public List<Enemy> entities;

    public static EntityMgr inst;
    private void Awake()
    {
        inst = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        // NOTE: Bounds spawn needs rework
        topBotBorders.Add(325f);
        topBotBorders.Add(-80f);
        leftRightBorders.Add(-190f);
        leftRightBorders.Add(190f);

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemy()
    {
        while (enemies.Count < maxEnemiesOnMap)
        {
            var posSpawn = new Vector3(leftRightBorders[Random.Range(0,2)], 0f, topBotBorders[Random.Range(0,2)]);
            var parent = GameObject.FindGameObjectWithTag("EnemyEntity");
            var newObj = Instantiate(enemyPrefab[0], posSpawn, Quaternion.identity, parent.transform);
            newObj.GetComponent<Enemy>().Position = posSpawn;

            // testing intercept command at spawn
            AIMgr.inst.HandleIntercept(player, newObj.GetComponent<Enemy>());

            enemies.Add(newObj.GetComponent<Enemy>());
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    public void DestroEnemy( /* which enemy */ )
    {

    }
}
