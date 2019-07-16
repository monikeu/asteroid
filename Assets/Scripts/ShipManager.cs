using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] Ship ship;
    [SerializeField] float minShipSpawnRange = 200f;
    [SerializeField] float shipsExistRange = 2000f;
    [SerializeField] int numberOfShipsExisting = 100;
    [SerializeField] Transform asteroid;

    private List<Ship> ships;
    private System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        ships = new List<Ship>();
        rand = new System.Random();
        PlaceShips();
    }

    void PlaceShips()
    {
        for (int i=0;i<numberOfShipsExisting;i++) 
        {
            ships.Add(InstantiateShip());
        }
    }

    Ship InstantiateShip()
    {
        Ship newShip = Instantiate(
            ship,
            new Vector3(
                asteroid.position.x + getRandomInRange(),
                0,
                asteroid.position.z + getRandomInRange()),
            Quaternion.identity, 
            transform);
        newShip.asteroid = asteroid;
        return newShip;
    }

    // Update is called once per frame
    void Update()
    {
        KillShipsOutOfRange();
        PlaceNewShipsInRange();
    }

    void KillShipsOutOfRange()
    {
        List<Ship> shipsToRemove = new List<Ship>();
        foreach (Ship ship in ships)
        {
            if (IsOutOfRange(ship)) {
                shipsToRemove.Add(ship);
            }
        }
        ships = ships.Except(shipsToRemove).ToList();
        foreach (Ship ship in shipsToRemove)
        {
            Destroy(ship.gameObject);
        }
    }

    bool IsOutOfRange(Ship ship)
    {
        float distanceX = Mathf.Abs(ship.transform.position.x - asteroid.position.x);
        float distanceZ = Mathf.Abs(ship.transform.position.z - asteroid.position.z);
        return distanceX >= shipsExistRange || distanceZ >= shipsExistRange;
    }

    void PlaceNewShipsInRange()
    {
        if (ships.Count < numberOfShipsExisting)
        {
            ships.Add(InstantiateShip());
        }
    }
    private float getRandomInRange()
    {
        if (rand.Next(0, 2) == 0) 
        {
            return UnityEngine.Random.Range(minShipSpawnRange, shipsExistRange);
        } 
        else 
        {
            return UnityEngine.Random.Range(-shipsExistRange, -minShipSpawnRange);
        }
    }
}
