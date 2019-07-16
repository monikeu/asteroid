using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private const float baseMovementSpeed = 10f;
    private const float movementSpeedRange = 0.2f;
    [SerializeField] public Transform asteroid;
    [SerializeField] Missile missile;
    [SerializeField] float visionRadius = 200f;
    [SerializeField] float safeRange = 50f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float movementSpeed;
    [SerializeField] float inFrontAngle = 10f; // in degrees
    [SerializeField] float reloadTime = 0.5f;
    [SerializeField] float missileDegSpread = 1.5f;
    bool canShoot = true;
    bool runningAway = false;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = baseMovementSpeed + Random.Range(-movementSpeedRange, movementSpeedRange) * baseMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (AsteroidIsInRange()) 
        {
            if (InSafeRange())
            {
                TurnToAsteroid();
                if (AsteroidInFront()) 
                {
                    Shoot();
                }
            }
            else 
            {
                RunAway();
            }
        } 
        else 
        {
            Patrol();
        }
    }

    bool AsteroidIsInRange()
    {
        float distance = Vector3.Distance(transform.position, asteroid.position);  
        return distance < visionRadius;
    }

    bool InSafeRange()
    {
        float distance = Vector3.Distance(transform.position, asteroid.position);
        return distance > safeRange;
    }

    void TurnToAsteroid() 
    {
        Vector3 targetDir = asteroid.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = rotationSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    bool AsteroidInFront()
    {
        Vector3 targetDir = asteroid.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        return angle < inFrontAngle;
    }

    void Shoot()
    {
        if (canShoot) 
        {
            Debug.Log("pew pew"); 
            Quaternion currentRotationLeft = new Quaternion(transform.rotation.x, transform.rotation.y + missileDegSpread * Mathf.Deg2Rad, transform.rotation.z, transform.rotation.w);
            Quaternion currentRotationRight = new Quaternion(transform.rotation.x, transform.rotation.y - missileDegSpread * Mathf.Deg2Rad, transform.rotation.z, transform.rotation.w);
            float angle = Vector3.Angle(new Vector3(0, 0, 1), transform.forward);
            Vector3 rightMissilePositionVector = new Vector3(2.3f, 0, 0.5f);
            Vector3 leftMissilePositionVector = new Vector3(-2.3f, 0, 0.5f);
            // Debug.DrawRay(transform.position, leftMissilePositionVector, Color.green, 1f, false);
            // Debug.DrawRay(transform.position, rightMissilePositionVector, Color.red, 1f, false);
            // Debug.Log("Rotating " + transform.eulerAngles.y + " degrees");
            rightMissilePositionVector = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * rightMissilePositionVector;
            leftMissilePositionVector = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * leftMissilePositionVector;
            // Debug.DrawRay(transform.position, leftMissilePositionVector, Color.green, 1f, false);
            // Debug.DrawRay(transform.position, rightMissilePositionVector, Color.red, 1f, false);
            
            Instantiate(
                missile,
                new Vector3(
                    transform.position.x + rightMissilePositionVector.x,
                    0,
                    transform.position.z + rightMissilePositionVector.z),
                currentRotationRight);
            Instantiate(
                missile,
                new Vector3(
                    transform.position.x + leftMissilePositionVector.x,
                    0,
                    transform.position.z + leftMissilePositionVector.z),
                currentRotationLeft);
            canShoot = false;
            Invoke("Reload", reloadTime);
        }

    }

    void Reload()
    {
        canShoot = true;
    }

    void RunAway() 
    {
        TurnAwayFromAsteroid();
        Thrust();
    }

    void TurnAwayFromAsteroid()
    {
        Vector3 targetDir = asteroid.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = rotationSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, -targetDir, step, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Patrol()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }

    void Thrust()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
