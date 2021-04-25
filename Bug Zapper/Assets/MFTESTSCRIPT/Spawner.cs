using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bugPrefab;
    public GameObject rockPrefab;

//    public int bugCount = 0;
    private float gameTime;
    public float timebetweenSpawn = 5;

    // Start is called before the first frame update
    void Start()
    {
        buildEnv(rockPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
    //   if (timebetweenSpawn % Mathf.Floor(gameTime) == 0)      //  Reverse timebetween and gameTime
        if (gameTime > timebetweenSpawn)
        {
            spawnBug();
            gameTime = 0;
        }
    }

    public void spawnBug()
    {
        GameObject bug = Instantiate(bugPrefab);
        bug.transform.position = new Vector3(0, 0, 0);
    //    bug.name = "Bug" + bugCount;
    }

    public void buildEnv(GameObject rockPrefab)
    {
        int rockCount = 0;
        UnityEngine.Vector3 home = new Vector3(0, 0, 0);

    //    UnityEngine.Random randX = new UnityEngine.Random();
    //    UnityEngine.Random randZ = new UnityEngine.Random();
        
        while (rockCount < 25)
        {
            GameObject rock = Instantiate(rockPrefab);
            rock.transform.position = new Vector3(Random.Range(-500.0f, 500.0f), 0, Random.Range(-500.0f, 500.0f));
            rockCount++;
        }
    }
}
