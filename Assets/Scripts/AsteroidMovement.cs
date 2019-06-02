﻿using System;
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

    [SerializeField] float collisionDamagePercentage = 0.00001f;
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.2f;
    //  1.0f/(24*60*gameLenInMinutes*1.0f)              
    [SerializeField] float resizeStep =0.000001f;

    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
        //UpdateSize();
        CheckSize();
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
    }

    void CheckSize()
    {
        if (myT.localScale.x < 0) {
            resizeStep = 0;
            gameObject.SetActive(false);
        }

        // tutaj sie konczy gra tak wlasciwie
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("dupa collider");
        Vector3 scale = myT.localScale;
        //scale.x = myT.localScale.x - (other.gameObject.transform.localScale.x * collisionDamagePercentage);
        //scale.y = myT.localScale.y - (other.gameObject.transform.localScale.y * collisionDamagePercentage);
        //scale.z = myT.localScale.z - (other.gameObject.transform.localScale.z * collisionDamagePercentage);
        scale.x = myT.localScale.x - (myT.localScale.x * collisionDamagePercentage);
        scale.y = myT.localScale.y - (myT.localScale.y * collisionDamagePercentage);
        scale.z = myT.localScale.z - (myT.localScale.z * collisionDamagePercentage);

        myT.localScale = scale;
    }
}
