using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
          
    [SerializeField] Texture texture;
    [SerializeField] float turnSpeed=5f;
    [SerializeField] float minScale = 1f;
    [SerializeField] float maxScale = 2f;

    void Start()
    {
       float d = Random.Range(minScale, maxScale);
       transform.localScale = new Vector3(d, d, d);
       //Texture gradient = (Texture) Resources.Load("Assets/Resources/gradient1.png");
       // Material material = GetComponent<Material>();
       // material.SetTexture(0, texture);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime,0));
    }
}
