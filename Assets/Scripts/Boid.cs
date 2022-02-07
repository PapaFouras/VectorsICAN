using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    BoidData boidData;
    private void Update() {
          
          transform.position += transform.forward * boidData.m_speed * Time.deltaTime;  
    }
}
