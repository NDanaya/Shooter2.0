using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        
    [SerializeField] private float force = 4;
    [SerializeField] private float damage = 1;
    [SerializeField] private GameObject impactPrefab;
    [SerializeField] private Transform shootPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
            {
                //print("Hit!!!");
                print(hit.transform.gameObject.name);

                Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));

                var destructible = hit.transform.GetComponent<DestructibleObjects>();

                if (destructible != null)
                {
                    destructible.ReceiveDamage(damage);
                }

                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                
                if (rigidbody != null)
                {
                    rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                }
                
                /*if (rigidbody == null)
                {
                    //hit.transform.gameObject.SetActive(false); убирает галочку в юнити/объекты
                    return;
                }*/
            }
            //print("Mouse clicked");
        }
    }
    }
}