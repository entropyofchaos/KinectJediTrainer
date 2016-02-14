using UnityEngine;
using System.Collections;

public class CallLaser : MonoBehaviour
{

    public HingeJoint hinge;
    void Update()
    {
        hinge = GetComponentInChildren<HingeJoint>();
        hinge.useSpring = false;

    }
}
