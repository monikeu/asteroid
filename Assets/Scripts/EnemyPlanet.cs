using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float minScale = 1f;
    [SerializeField] float maxScale = 2f;
    [SerializeField] float d = 5f;
    public Vector3 enemyPosition=new Vector3(100, 100, 0);

    void Start()
    {
        transform.localScale = new Vector3(d, d, d);
        transform.position = enemyPosition;


        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Asteroid")
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("The end");

        }
    }
}