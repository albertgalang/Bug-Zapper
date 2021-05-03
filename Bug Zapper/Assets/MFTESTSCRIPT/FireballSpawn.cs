using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public float projectileSpeed;
    private Vector3 target;
    private Vector3 playerPosition;
    private Quaternion playerQuarternion;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                var intersectionPt = hit.point;
                GameObject fireball = Instantiate(projectile, player.transform.position, Quaternion.identity);
                fireball.transform.LookAt(hit.point);
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = projectileSpeed * transform.forward;
            }
        }
    }

    /*
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
    */
}
