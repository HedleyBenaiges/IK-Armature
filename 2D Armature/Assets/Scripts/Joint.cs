using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;
    public GameObject m_pole;
    
    public Joint getChild(){
        return m_child;
    }
    public GameObject getPole() {
        return m_pole;
    }

    public void rotate(float _angle){
        transform.Rotate(Vector3.forward * _angle);
    }
}
