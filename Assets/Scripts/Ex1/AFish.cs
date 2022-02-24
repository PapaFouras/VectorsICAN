using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFish : MonoBehaviour
{
    [SerializeField]
    public FishData fishData;

    [SerializeField]
    Vector3 boxCenter;

    [SerializeField]
    float boxRadius;

    virtual public void InitFish(float _boxRadius){
        boxRadius = _boxRadius;
        boxCenter = Vector3.zero;
        fishData = new FishData();
        fishData.m_speed = Random.Range(2.5f,4f);
    }

    private IEnumerator Reflect(Vector3 norm){

        fishData.m_color = Color.red;
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();        
        transform.forward  =(transform.forward - 2 * (Vector3.Dot(transform.forward, norm))*norm) ;
        transform.position += transform.forward * fishData.m_speed * Time.deltaTime;

        yield return new WaitForEndOfFrame();
        if(!isInsideOfBorder()){
            float x = Mathf.Clamp(transform.position.x,boxCenter.x - boxRadius,boxCenter.x + boxRadius);
            float y = Mathf.Clamp(transform.position.y,boxCenter.y - boxRadius,boxCenter.y + boxRadius);
            float z = Mathf.Clamp(transform.position.z,boxCenter.z - boxRadius,boxCenter.z + boxRadius);
            transform.position = new Vector3(x,y,z);
        }
            
        
    }

    private bool isInsideOfBorder(){
        if (transform.position.x < boxCenter.x - boxRadius){
            return false;
        }
        else if(transform.position.x > boxCenter.x + boxRadius){
            return false;
        }
        else if(transform.position.y < boxCenter.y - boxRadius){
            return false;
        }
        else if(transform.position.y > boxCenter.y + boxRadius){
            return false;
        }
        else if(transform.position.z < boxCenter.z - boxRadius){
            return false;
        }
        else if(transform.position.z > boxCenter.z + boxRadius){
            return false;
        }            
        else
        {
            // boidData.m_color = Random.ColorHSV();
            // gameObject.GetComponent<Renderer>().material.color = boidData.m_color; 
            return true; 
        }
    }

        private bool isInsideOfBorderAndReflect(){
        if (transform.position.x < boxCenter.x - boxRadius){
            StartCoroutine(Reflect(new Vector3(1,0,0)));
            return false;
        }
        else if(transform.position.x > boxCenter.x + boxRadius){
            StartCoroutine(Reflect(new Vector3(-1,0,0)));
            return false;
        }
        else if(transform.position.y < boxCenter.y - boxRadius){
            StartCoroutine(Reflect(new Vector3(0,1,0)));
            return false;
        }
        else if(transform.position.y > boxCenter.y + boxRadius){
            StartCoroutine(Reflect(new Vector3(0,-1,0)));
            return false;
        }
        else if(transform.position.z < boxCenter.z - boxRadius){
            StartCoroutine(Reflect(new Vector3(0,0,1)));
            return false;
        }
        else if(transform.position.z > boxCenter.z + boxRadius){
            StartCoroutine(Reflect(new Vector3(0,0,-1)));
            return false;
        }            
        else
        {
            // boidData.m_color = Random.ColorHSV();
            // gameObject.GetComponent<Renderer>().material.color = boidData.m_color; 

            return true; 
        }
    }

    private void Move(){
        isInsideOfBorderAndReflect();
        transform.position += transform.forward * fishData.m_speed * Time.deltaTime;
        
    }

    virtual protected void FixedUpdate() {
        Move();
    }

}
