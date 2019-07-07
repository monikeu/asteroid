using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    [SerializeField] private AsteroidMovement asteroid;
    

    void Start()
    {    
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = asteroid.transform.position;
        transform.localScale = asteroid.transform.localScale;
    }
    
    
}