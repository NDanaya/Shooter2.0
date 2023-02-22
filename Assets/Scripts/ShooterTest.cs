using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterTest : MonoBehaviour
{
    //public float force2 = 10;
    [SerializeField]private float force = 11;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                //print("Hit!!!");
                print(hit.transform.gameObject.name);
                
                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody == null)
                {
                    //hit.transform.gameObject.SetActive(false); убирает галочку в юнити/объекты
                    return;
                }
                rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
            }
            //print("Mouse clicked");
        }
    }
}
