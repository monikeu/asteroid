using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float missileSpeed = 20f;
    [SerializeField] float aliveTime = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        transform.position += transform.forward * missileSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
