using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public ParticleSystem Muzzle;

    float FireRate = 20f;
    float FireTime;
    public float Damage;

    void Start()
    {
        
    }


    void Update()
    {

    if (Input.GetButton("Fire1"))
    {
            if(Time.time >= FireTime) 
            {

                Shoot();
                FireTime = Time.time + 1 / FireRate;
                    
                    
            }
         


    }

    }

    void Shoot()
    {
        Muzzle.Play();

        RaycastHit Hit;

       if(  Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out Hit, 100f))
        {

            HealthManager hm = Hit.transform.GetComponent<HealthManager>();

            if (hm)
            {


                hm.TakeDamage(Damage);


            }

        }



    }
}
