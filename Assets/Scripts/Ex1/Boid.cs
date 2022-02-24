using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : AFish
{
    List<Boid> nearbyBoids = new List<Boid>();

    public float xAngle = .8f * Mathf.PI;


    public float zAngle = 0.5f * 0.5f * Mathf.PI;

    public float precision = .1f*Mathf.PI;
    public float viewDistance = 1f;

  override protected void FixedUpdate() {
      DetectNearbyBoids();
      base.FixedUpdate();
  } 

  private void DetectNearbyBoids(){
      nearbyBoids.Clear();
    // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        //Does the ray intersect any objects excluding the player layer

        for(float i = -xAngle; i < xAngle; i+=precision){
            for(float j = -zAngle; j < zAngle; j+=precision){
                float x =  Mathf.Sin(i);//Mathf.Sin(i);
                float y = Mathf.Sin(j) ;
                float z = Mathf.Cos(i);//Mathf.Sin(i);
                
                Vector3 pos = transform.rotation * new Vector3(x,y,z);
                Debug.DrawRay(transform.position,  pos  * viewDistance, Color.white);
    
                if (Physics.Raycast(transform.position, pos , out hit, viewDistance, layerMask))
                {
                    if(isBoidFish(hit)){
                        Debug.DrawRay(transform.position, pos * hit.distance, Color.yellow);
                    } 
                }
            }
         }
        
        
}
private bool isBoidFish(RaycastHit _hit){
    if(_hit.collider.gameObject.GetComponent<LeaderFish>() != null)
    {
                nearbyBoids.Add(_hit.collider.gameObject.GetComponent<Boid>());
                Debug.Log("Did Hit");
                return true;
    }
    else{
        return false;
    }
}
      
  
}
