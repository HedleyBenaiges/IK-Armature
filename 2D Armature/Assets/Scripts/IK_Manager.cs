using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

// Ref: https://www.youtube.com/watch?v=VdJGouwViPs

public class IK_Manager : MonoBehaviour
{

    //Root of the robot arm (armature)
    public Joint m_root;
    // End node of a robot arm (end affector)
    public Joint m_end;
    public GameObject m_target;
    public float m_threshold = 0.2f;
    public float m_rate = 5f;
    public int m_steps = 20;

    float calculateSlope(Joint _joint){
        float deltaTheta = 0.01f;
        float distance1 = getDistance(m_end.transform.position, m_target.transform.position);

        _joint.rotate(deltaTheta);

        float distance2 = getDistance(m_end.transform.position, m_target.transform.position);

        _joint.rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }

    void moveToPole(Joint _current) {
        if (_current.getChild().getPole() != null) {
            Joint child = _current.getChild();
            GameObject childPole = _current.getChild().getPole();

            float theta = Vector2.Angle(child.transform.position, m_end.transform.position);

            float d1 = getDistance(child.transform.position, childPole.transform.position);
            _current.rotate(theta * 2);
            float d2 = getDistance(child.transform.position, childPole.transform.position);

            // If further away after the move, return to original position
            if (d1 < d2) {
                _current.rotate(theta * -2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < m_steps; i++){
            if(getDistance(m_end.transform.position, m_target.transform.position) > m_threshold){

                Joint current = m_root;
                while(current != null){
                    float slope = calculateSlope(current);
                    current.rotate(-slope * m_rate);

                    // Will flip the joint so it tends towards the pole
                    // moveToPole(current);

                    current = current.getChild();
                }

            }
        }
    }

    float getDistance(Vector3 _point1, Vector3 _point2){
        return Vector3.Distance(_point1, _point2);        
    }
}
