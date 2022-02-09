using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    BoidData boidData;

    [SerializeField]
    Vector3 boxCenter;

    [SerializeField]
    float boxRadius = 5f;
    private bool isOutsideOfBorder(){
        if (
            //Calcul des x
            (transform.position.x < boxCenter.x - boxRadius || transform.position.x > boxCenter.x + boxRadius) ||
            (transform.position.y < boxCenter.y - boxRadius || transform.position.y > boxCenter.y + boxRadius) ||
            (transform.position.z < boxCenter.z - boxRadius || transform.position.z > boxCenter.z + boxRadius)  
            )
            {
                boidData.m_color = Color.red;
                return true;
            }
            else
            {
                boidData.m_color = Color.green;
                return false;
            }
    }
    private void Update() {
          

        

          transform.position += transform.forward * boidData.m_speed * Time.deltaTime;  
    }
}
