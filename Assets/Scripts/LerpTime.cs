using System;
using UnityEngine;
using System.Collections;

abstract class LerpTime<T> : MonoBehaviour
{
    [SerializeField]
    public T startValue;

    [SerializeField]
    public T endValue;

    private float currentTime = 0f;

    public abstract T LerpAtTime(float alpha);
    public IEnumerator LerpRoutine(T value, float totalDuration){
        currentTime = 0f;
        while(currentTime < totalDuration){
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            value = LerpAtTime(currentTime);
            if(currentTime >= totalDuration){
                currentTime = 1f;
                value = LerpAtTime(currentTime);
                yield break;
            }
        }
    }
}

class LerpPosition : LerpTime<Vector3> {

   public override Vector3 LerpAtTime(float currentTime){
       return startValue + currentTime *(endValue-startValue);
   }
}

class LerpFloat : LerpTime<float> {

   public override float LerpAtTime(float currentTime){
       return startValue + currentTime *(endValue-startValue);
   }
}

class LerpQuaternion : LerpTime<Quaternion> {

   public override Quaternion LerpAtTime(float currentTime){
       //J'avoue j'ai pas voulu faire le calcul de substract pour les quaternions
       return Quaternion.Lerp(startValue,endValue,currentTime);
   }
}


class LerpInt : LerpTime<int> {

   public override int LerpAtTime(float currentTime){
       //J'avoue j'ai pas voulu faire le calcul de substract pour les quaternions
       return Mathf.RoundToInt(startValue + currentTime *(endValue-startValue));
   }
}
