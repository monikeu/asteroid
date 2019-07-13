using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CommunicatesManager : MonoBehaviour
{
    [SerializeField] private Text displayText;
    
    private Vector3 diff = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
    private EnemyPlanet enemyPlanet;
    private AsteroidMovement asteroid;

    private List<String> closerCommunicates = new List<string>(new string[] {"Getting Closer"});
    private List<String> noMoveCommunicates = new List<string>(new string[] {"I have to move"});
    private List<String> furtherCommunicates = new List<string>(new string[] {"I feel it's a wrong way"});

    private List<String> philosophicalThoughts = new List<string>(new string[]
    {
        "I will destroy them", 
        "Do I really want all of their people to die?",
        "They killed all of my people, the whole kind, they deserve the same",
        "I'm ... I'm falling apart!",
        "I don't have much time",
        "I can't waste time for another planets!",
        "I will destroy everything!",
        
        
    });

    private Random random = new Random();


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started CommunicatesManager");
        enemyPlanet = FindObjectOfType<EnemyPlanet>();
        asteroid = FindObjectOfType<AsteroidMovement>();
        Debug.Log(diff);

        // 23 and 29 are primes, which means that they will cross on 23*29 time, it's longer than desired game
        // lenght (600 seconds) which means that philosophical communicates won't update at the same time as the other ones.
        InvokeRepeating("UpdateCommunicates", 20f, 11f);

    }

    void UpdateCommunicates()
    {
        Debug.Log("Regular Communicate Update");

        Vector3 vecDiff = (enemyPlanet.enemyPosition - asteroid.transform.position);
        if (vecDiff.magnitude < diff.magnitude)
        {
            displayText.text = closerCommunicates[random.Next(0, closerCommunicates.Count)];
        }
        else if (Math.Abs(vecDiff.magnitude - diff.magnitude) < 0.01)
        {
            displayText.text = noMoveCommunicates[random.Next(0, noMoveCommunicates.Count)];
        }
        else
        {
            displayText.text = furtherCommunicates[random.Next(0, furtherCommunicates.Count)];
        }

        diff = vecDiff;

        // decide if thought should be displayed instead of directi9on hint
        if (random.Next(0, 2) == 1)
        {
            displayText.text= philosophicalThoughts[random.Next(0, philosophicalThoughts.Count)];
        }
    }


}