using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpace : MonoBehaviour
{
    [SerializeField] AsteroidMovement asteroid;
    [SerializeField] int size=100;
    Transform myT;

    void Start()
    {
        swapNormals();
    }

        // Start is called before the first frame update
        void Awake()
        {
            myT = transform;
            myT.localScale = new Vector3(size, size, size);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = asteroid.transform.position;
        }
    

    private void swapNormals()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] triangles = mesh.GetTriangles(i);

            for (int j = 0; j < triangles.Length; j += 3)
            {
                int tmp = triangles[j];
                triangles[j] = triangles[j + 1];
                triangles[j + 1] = tmp;
            }

            mesh.SetTriangles(triangles, i);
        }
    }
}
