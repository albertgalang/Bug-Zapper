using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
    [SerializeField]
    private Player player;
    //[SerializeField]
    //private List<Enemy> enemies = new List<Enemy>();

    public Player Player { get => this.player; }
    //public List<Enemy> Enemies { get => this.enemies; }

    //list of bug enemies
    public List<BugEntity> entities;

    public static EntityMgr inst;
    private void Awake()
    {
        inst = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
