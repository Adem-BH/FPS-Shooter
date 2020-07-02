using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [SerializeField] float MouseSensitivity;
     Rigidbody Player;
    float RotationX;


    void Start()
    {

        Player = GameObject.Find("Player").GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

  
    void Update()
    {

        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        RotationX -= MouseY;
        RotationX = Mathf.Clamp(RotationX, -90f, 90f);

        Player.rotation = Quaternion.Euler(Player.rotation.eulerAngles + Vector3.up * MouseX);

        transform.localRotation = Quaternion.Euler(RotationX, 0, 0);




    }
}
