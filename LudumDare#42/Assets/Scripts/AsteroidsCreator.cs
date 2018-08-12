using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsCreator : MonoBehaviour
{

    public GameObject asteroid1, asteroid2;
    GameObject ast;
    public Vector3 center;
    public Vector3 size;
    float n;

    void Start()
    {
        center = transform.position;
        size = transform.localScale;
        InvokeRepeating("CountofAsteroids", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CountofAsteroids()
    {
        center = transform.position;
        for (int i = 0; i < Random.Range(6, 11); i++)
        {
            n = Random.Range(1, 5);
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            if (Random.Range(0, 2) == 0)
            {
                asteroid1.transform.localScale = new Vector3(n, n, n);
                ast = Instantiate(asteroid1, pos, Quaternion.identity);
                ast.GetComponent<AsteroidsBehavior>().directionrotate = new Vector3(Random.Range(0.1f, 1.1f), Random.Range(0.1f, 1.1f), Random.Range(0.1f, 1.1f));
                ast.GetComponent<AsteroidsBehavior>().direction = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
                return;
            }
            asteroid2.transform.localScale = new Vector3(n, n, n);
            ast = Instantiate(asteroid2, pos, Quaternion.identity);
            ast.GetComponent<AsteroidsBehavior>().directionrotate = new Vector3(Random.Range(0.1f, 1.1f), Random.Range(0.1f, 1.1f), Random.Range(0.1f, 1.1f));
            ast.GetComponent<AsteroidsBehavior>().direction = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        }
    }
}