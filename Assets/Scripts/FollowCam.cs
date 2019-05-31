using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -5f);
    [SerializeField] float distanceDamp = 5f;
    Vector3 velocity = Vector3.one;
    Transform myT;

    // Start is called before the first frame update
    void Awake()
    {
        myT = transform;
    }


    void LateUpdate()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;

        myT.LookAt(target, target.up);


        //Vector3 toPos = target.position + (target.rotation * defaultDistance);
        //Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);

        //Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
        //Quaternion curRotation = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);

        //myT.position = curPos;
        //myT.rotation = toRot;
    }
}
