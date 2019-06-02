using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
          
    [SerializeField] float turnSpeed=5f;
    [SerializeField] float minScale = 1f;
    [SerializeField] float maxScale = 2f;

    void Start()
    {
       float d = Random.Range(minScale, maxScale);
       transform.localScale = new Vector3(d, d, d);
        Texture gradient = (Texture)Resources.Load("gradient1.png");
        //Material material = GetComponent<Material>();

        //material.SetColor("_Color", new Color(150, 0, 0, 50));
        GetComponent<Renderer>().material.SetTexture("_MainTex", gradient);
        //GetComponent<Renderer>().material.color = new Color(0.15f, 0f, 0f, 0.5f);
        //Shader shader = GetComponent<Shader>();
        //shader..SetTexture("_MainTex", gradient);
        // material.SetTexture(0, texture);

        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime,0));
    }

    void OnTriggerEnter()
    {
        gameObject.SetActive(false);
    }

    //private float getRandom()
    //{
    //    return (planetsSpacing * Random.Range(minSpacingScale, maxSpacingScale));
    //}
}
