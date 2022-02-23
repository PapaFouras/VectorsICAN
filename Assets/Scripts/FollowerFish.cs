using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerFish : AFish
{
    GameObject leaderFishToFollow;

    float viewDistance = 7f;
    float xAngle = .4f;
    float zAngle = .4f;

    float precision = .1f;
  protected override void FixedUpdate() {
      base.FixedUpdate();

      DetectLeaderFish();
      if(leaderFishToFollow != null){
          transform.forward = (leaderFishToFollow.transform.position - transform.position).normalized;
      }



  }
private void DetectLeaderFish(){
    // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        //Does the ray intersect any objects excluding the player layer

        for(float i = -xAngle; i < xAngle; i+=precision){
            for(float j = -zAngle * Mathf.Cos(i/xAngle); j < zAngle * Mathf.Cos(i/xAngle); j+=precision){
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(i,j,0)) * viewDistance, Color.white);

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(i,j,0)), out hit, viewDistance, layerMask))
                {
                    if(isLeaderFish(hit)){
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(i,j,0)) * hit.distance, Color.yellow);
                        return;
                    }

                    
                }
            }
         }
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewDistance, layerMask))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     if(isLeaderFish(hit)){
        //         return;
        //     }
            
        // }
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(xAngle,0,0)), out hit, viewDistance, layerMask))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     if(isLeaderFish(hit)){
        //         return;
        //     }
        // }
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(-xAngle,0,0)), out hit, viewDistance, layerMask))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     if(isLeaderFish(hit)){
        //         return;
        //     }
        // }
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,zAngle,0)), out hit, viewDistance, layerMask))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     if(isLeaderFish(hit)){
        //         return;
        //     }
        // }
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,-zAngle,0)), out hit, viewDistance, layerMask))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     if(isLeaderFish(hit)){
        //         return;
        //     }
        // }
        
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(xAngle,0,0)) * viewDistance, Color.white);
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(-xAngle,0,0)) * viewDistance, Color.white);
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,zAngle,0)) * viewDistance, Color.white);
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,-zAngle,0)) * viewDistance, Color.white);
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * viewDistance, Color.white);
            leaderFishToFollow = null;

           // Debug.Log("Did not Hit");
        
}
private bool isLeaderFish(RaycastHit _hit){
    if(_hit.collider.gameObject.GetComponent<LeaderFish>() != null)
    {
                leaderFishToFollow = _hit.collider.gameObject;
                Debug.Log("Did Hit");
                return true;
    }
    else{
        return false;
    }
}
public override void InitFish(float _boxRadius)
    {
        base.InitFish(_boxRadius);
        //fishData.m_speed = Random.Range(2f,3f);
        fishData.m_speed = 4f;
        Destroy(gameObject.GetComponent<CapsuleCollider>());

    }
  
}
