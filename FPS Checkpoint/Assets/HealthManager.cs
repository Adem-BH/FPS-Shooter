using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [SerializeField] float Health;
    [SerializeField] Behaviour[] SwitchOnDeath;
    [SerializeField] bool Dead = false;

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void TakeDamage(float Ammount)
    {

        Health -= Ammount;
        if (Dead) return;

                if (Health<= 0)
        {

            Health = 0;
            Die();

        }

    }

    public void Die()
    {

        Dead = true;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 4f);
        foreach(Behaviour b in SwitchOnDeath)
        {

            b.enabled = !b.enabled;

        }


        try
        {
            GetComponent<Animator>().SetTrigger("Dead");
        }
        catch
        {
            Debug.Log("No Animator found");
        }

    }


}
