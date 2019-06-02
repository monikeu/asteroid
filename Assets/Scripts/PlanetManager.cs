using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{

    [SerializeField]Planet planet;
    [SerializeField]int numbOfPlanetsInOneAxis=5;
    [SerializeField]int planetsSpacing=100;
    [SerializeField] float minSpacingScale = 10f;
    [SerializeField] float maxSpacingScale =50f;

    private void Start()
    {
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
                transform.position.x + (x * getRandom())+ getRandom(),
                transform.position.y + (y * getRandom())+ getRandom(),
                transform.position.z + (z * getRandom()) + getRandom()
                ),
            Quaternion.identity, transform);
    }

    private float getRandom()
    {
        return (planetsSpacing * Random.Range(minSpacingScale, maxSpacingScale));
    }
}
