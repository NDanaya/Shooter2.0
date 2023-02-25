using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    
    [SerializeField] private float delay = 3f;
    [SerializeField] private GameObject explosionEffect;

    private float countdown;
    private bool hasExploded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        //Debug.Log("BOOM!");

        Instantiate(explosionEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);

    }
}
