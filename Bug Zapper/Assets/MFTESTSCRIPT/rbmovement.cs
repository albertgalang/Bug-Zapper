using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbmovement : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 position;
    public float speed = 150.0f;
    public Rigidbody rb;
    public Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    /*
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));    
    }
    */

    private void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
