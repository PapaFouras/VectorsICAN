using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBetween2Points : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPos = Vector3.zero;
    
    [SerializeField]
    private Vector3 endPos = Vector3.one;
    [SerializeField]
    private float durationInSeconds = 5f;

    private bool isFinished = false;

    [SerializeField]
    private AnimationCurve m_AC;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startMovement());
    }

    private IEnumerator startMovement(){
        float time = 0f;
        float alpha = 0f;
        while(!isFinished){
            time+=Time.deltaTime;
            alpha= time/durationInSeconds;
            Debug.Log(alpha);
            transform.position = Vector3.Lerp(startPos,endPos,m_AC.Evaluate(alpha));
            yield return new WaitForEndOfFrame();
            if(alpha>= 1){
                isFinished = true;
                transform.position = Vector3.Lerp(startPos,endPos,1);
            }
        }
        isFinished = false;
        Debug.Log("isfinished");
      
    }

}
