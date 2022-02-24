using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerFish : AFish
{
    GameObject leaderFishToFollow;

    float xAngle = .8f * Mathf.PI;

    float zAngle = 0.8f * 0.5f * Mathf.PI;

    float precision = .1f*Mathf.PI;

    float viewDistance = 7f;



  protected override void FixedUpdate() {

      DetectLeaderFish();
      if(leaderFishToFollow != null){
          transform.forward = (leaderFishToFollow.transform.position - transform.position).normalized;
      }

      base.FixedUpdate();


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
            for(float j = -zAngle; j < zAngle; j+=precision){
                float x =  Mathf.Sin(i);//Mathf.Sin(i);
                float y = Mathf.Sin(j) ;
                float z = Mathf.Cos(i);//Mathf.Sin(i);
                
                Vector3 pos = transform.rotation * new Vector3(x,y,z);
                //Debug.DrawRay(transform.position,  pos  * viewDistance, Color.white);
    
                if (Physics.Raycast(transform.position, pos , out hit, viewDistance, layerMask))
                {
                    if(isLeaderFish(hit)){
                        Debug.DrawRay(transform.position, pos * hit.distance, Color.yellow);
                        return;
                    } 
                }
            }
         }
        leaderFishToFollow = null;
        
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
