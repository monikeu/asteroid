using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] Planet planet;
    [SerializeField] int numbOfPlanetsInOneAxis = 5;
    [SerializeField] int planetsSpacing = 100;
    [SerializeField] float minSpacingScale = 10f;
    [SerializeField] float maxSpacingScale = 50f;
    [SerializeField] float minPlanetSpawnRange = 200f;
    [SerializeField] float planetsExistRange = 2000f;
    [SerializeField] int numberOfPlanetsExisting = 100;
    [SerializeField] Transform asteroid;

    private List<Planet> planets;
    private System.Random rand;

    [SerializeField] private Material mat1;
    [SerializeField] private Material mat2;
    [SerializeField] private Material mat3;
    [SerializeField] private Material mat4;
    [SerializeField] private Material mat5;
    [SerializeField] private Material mat6;
    private ArrayList materials;


    private void Start()
    {
        planets = new List<Planet>();
        rand = new System.Random();
        addMaterials();
        PlacePlanets();
    }

    void PlacePlanets()
    {
        for (int i=0;i<numberOfPlanetsExisting;i++) 
        {
            planets.Add(InstantiatePlanet());
        }
        for (int i = -numbOfPlanetsInOneAxis; i < numbOfPlanetsInOneAxis; i++)
        {
            for (int j = -numbOfPlanetsInOneAxis; j < numbOfPlanetsInOneAxis; j++)
            {
                for (int k = -numbOfPlanetsInOneAxis; k < numbOfPlanetsInOneAxis; k++)
                    InstianatePlanet(i, j, k);
            }
        }
    }

    Planet InstantiatePlanet()
    {
        return Instantiate(
            planet,
            new Vector3(
                asteroid.position.x + getRandomInRange(),
                0,
                asteroid.position.z + getRandomInRange()),
            Quaternion.identity, 
            transform);
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

    void Update()
    {
        KillPlanetsOutOfRange();
        PlaceNewPlanetsInRange();
    }

    void KillPlanetsOutOfRange() 
    {
        List<Planet> planetsToRemove = new List<Planet>();
        foreach (Planet planet in planets)
        {
            if (IsOutOfRange(planet)) {
                planetsToRemove.Add(planet);
            }
        }
        planets = planets.Except(planetsToRemove).ToList();;
        foreach (Planet planet in planetsToRemove)
        {
            Destroy(planet.gameObject);
        }
    }

    bool IsOutOfRange(Planet planet)
    {
        float distanceX = Mathf.Abs(planet.transform.position.x - asteroid.position.x);
        float distanceZ = Mathf.Abs(planet.transform.position.z - asteroid.position.z);
        return distanceX >= planetsExistRange || distanceZ >= planetsExistRange;
    }

    void PlaceNewPlanetsInRange()
    {
        if (planets.Count < numberOfPlanetsExisting)
        {
            planets.Add(InstantiatePlanet());
        }
    }

    private float getRandomInRange()
    {
        if (rand.Next(0, 2) == 0) 
        {
            return UnityEngine.Random.Range(minPlanetSpawnRange, planetsExistRange);
        } 
        else 
        {
            return UnityEngine.Random.Range(-planetsExistRange, -minPlanetSpawnRange);
        }
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