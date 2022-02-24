using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalisticRenderer : MonoBehaviour
{
    [SerializeField]
    private LineRenderer m_LineRendered ;
    [Range(1,60)]
    [SerializeField]
    private int m_nb_pointsRendered = 30;
    [Range(-180,180)]
    [SerializeField]
    private float angleAlpha = 45f;

    [Range(-180,180)]
    [SerializeField]
    private float angleBeta = 0f;
    
    [SerializeField]
    private float m_impulseForce = 100f;

    [Range(1,20)]
    [SerializeField]
    private int m_renderedDensity = 10;
    [SerializeField]
    private float m_gravity = 9.8f;
   
    [SerializeField]
    private float m_friction = 10f;


    // Update is called once per frame
    private void OnValidate() {
        m_LineRendered.positionCount = m_nb_pointsRendered*m_renderedDensity;
        Vector3[] positions = new Vector3[m_nb_pointsRendered*m_renderedDensity];
        positions[0] = Vector3.zero;
        float cosAngle = Mathf.Cos(Mathf.Deg2Rad*angleAlpha);
        float sinAngle = Mathf.Sin(Mathf.Deg2Rad*angleAlpha);

        for(int i = 0; i< m_nb_pointsRendered; i++){
            for(int j = 0; j < m_renderedDensity; j++){


                float t = i+((float)j/m_renderedDensity);

                float x = m_impulseForce*sinAngle*t*Mathf.Sin(Mathf.Deg2Rad*angleBeta); 

                float y = (-.5f*m_gravity)*t*t + m_impulseForce*cosAngle*t;
                
                float z = Mathf.Cos(Mathf.Deg2Rad*angleBeta)*sinAngle*m_impulseForce*t;

                positions[i*m_renderedDensity+j] = new Vector3(x,y,z);
            }
            
        }
       m_LineRendered.SetPositions(positions);
    }

}
