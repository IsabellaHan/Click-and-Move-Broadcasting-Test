using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform Target;

    void LateUpdate()
    {
        if(Target)
        {
            this.transform.position = new Vector3(Target.position.x, Target.position.y+7, Target.position.z);
        }
    }
}
