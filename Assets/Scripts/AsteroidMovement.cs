using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Transform myT;

     void Awake()
    {
        myT = transform;    
    }

    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.2f;
    //  1.0f/(24*60*gameLenInMinutes*1.0f)              
    [SerializeField] float resizeStep = 1.0f/(24*60*10*1.0f);
    [SerializeField] float beginScale = 1.0f;


    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
       // UpdateSize();
        
    }

    void Turn() {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Yaw");
        //float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        //float roll = turnSpeed * Time.deltaTime * Random.Range(minScale, maxScale);
        myT.Rotate(0,yaw, 0);
            
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }

    }

    void UpdateSize()
    {
        Vector3 scale = myT.localScale;
        scale.x = myT.localScale.x - resizeStep;
        scale.y = myT.localScale.y - resizeStep;
        scale.z = myT.localScale.z - resizeStep;
        myT.localScale = scale;
        // to do zaimplmentowac zeby   sie cokolwiek dzialo jak staeroida zmaleje do zera
    }
}
