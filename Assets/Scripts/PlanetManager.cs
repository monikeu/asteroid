using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] Planet planet;
    [SerializeField] int numbOfPlanetsInOneAxis = 5;
    [SerializeField] int planetsSpacing = 100;
    [SerializeField] float minSpacingScale = 10f;
    [SerializeField] float maxSpacingScale = 50f;

    [SerializeField] private Material mat1;
    [SerializeField] private Material mat2;
    [SerializeField] private Material mat3;
    [SerializeField] private Material mat4;
    [SerializeField] private Material mat5;
    [SerializeField] private Material mat6;
    private ArrayList materials;


    private void Start()
    {
        addMaterials();
        PlacePlanets();
    }

    void PlacePlanets()
    {
        for (int i = -numbOfPlanetsInOneAxis; i < numbOfPlanetsInOneAxis; i++)
        {
            for (int j = -numbOfPlanetsInOneAxis; j < numbOfPlanetsInOneAxis; j++)
            {
                for (int k = -numbOfPlanetsInOneAxis; k < numbOfPlanetsInOneAxis; k++)
                    InstianatePlanet(i, j, k);
            }
        }
    }

    void InstianatePlanet(int x, int y, int z)
    {
        Instantiate(planet,
            new Vector3(
                transform.position.x + (x * getRandom()) + getRandom(),
                transform.position.y + (y * getRandom()) + getRandom(),
                transform.position.z + (z * getRandom()) + getRandom()
            ),
            Quaternion.identity, transform);
        planet.GetComponent<Renderer>().material = GetRandMaterial();
    }

    private float getRandom()
    {
        return (planetsSpacing * Random.Range(minSpacingScale, maxSpacingScale));
    }

    private Material GetRandMaterial()
    {
        return (Material) materials[Random.Range(0, materials.Count)];
    }

    private void addMaterials()
    {
        materials = new ArrayList();
        materials.Add(mat1);
        materials.Add(mat2);
        materials.Add(mat3);
        materials.Add(mat4);
        materials.Add(mat5);
        materials.Add(mat6);
    }
}