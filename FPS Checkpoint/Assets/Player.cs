using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    Rigidbody rb;

    public float JumpForce;
    public CapsuleCollider Col;
    public LayerMask Ground;

    [SerializeField] float Gravity;
    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * Gravity;
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 Direction = transform.right * x + transform.forward * y;

        Vector3 Mouvement = Direction.normalized * Speed * Time.deltaTime;

        rb.MovePosition(rb.position + Mouvement);

        rb.angularVelocity = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
        
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

        }

       

    }

    bool Grounded()
    {

       return Physics.CheckCapsule(Col.bounds.center, new Vector3(Col.bounds.center.x, Col.bounds.min.y, Col.bounds.center.z), Col.radius * 0.9f, Ground);

    }
}
