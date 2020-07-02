using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class zombie : MonoBehaviour
{

    Transform Player;
    Rigidbody rb;
    Animator ar;
    public float Speed;
    public Vector3 Direction;

    HealthManager playerHealthManager;
    bool dealDamage;
    [SerializeField] float damage;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        ar = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
        playerHealthManager = Player.GetComponent<HealthManager>();

    }

 
    void Update()
    {
        if (dealDamage && playerHealthManager) 
        {
            playerHealthManager.TakeDamage(damage * Time.deltaTime);


                ar.SetTrigger("Attack");
        }

        if (!Player.transform)
        {

            Direction = Vector3.zero;

        }

        Direction = Player.transform.position - transform.position;

        Direction.y = 0;

        rb.rotation = Quaternion.LookRotation(Direction);

        rb.angularVelocity = Vector3.zero;

        rb.MovePosition(rb.position + Direction * Speed * Time.deltaTime);

        ar.SetFloat("MoveSpeed", 1);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = false;
    }

   
}
