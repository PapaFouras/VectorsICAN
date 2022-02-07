using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonoBehaviour
{
    [SerializeField]
    GameObject boidPrefab;

    public float boxSize = 10;

    
    int m_nb_boids_spawned = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<m_nb_boids_spawned; i++){
            var position = new Vector3(Random.Range(-boxSize, boxSize),Random.Range(-boxSize, boxSize),Random.Range(-boxSize, boxSize));
            Instantiate(boidPrefab,position, new Quaternion(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
