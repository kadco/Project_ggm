using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KFollowTransform : MonoBehaviour {

    public Transform _targetTransform;
    public Vector3 targetOffset = new Vector3(1f, 1.7f, 0);  //FPS

    float fDistance_cur;
    float fSmoothTime = 0.0F;    // smooth, smaller is faster. //보정
    private float fVelocity = 0.0f;
    private Vector3 Velocity = Vector3.zero;    

    private float angleVelocity = 0.0f;
    private float angularSmoothTime = 5.0f;
    private float angularMaxSpeed = 10.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void LateUpdate()
    {
        if (!_targetTransform) return;

        Vector3 targetPos = (_targetTransform.position + targetOffset); 
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref Velocity, Time.deltaTime * fSmoothTime);

        Quaternion targetRot = _targetTransform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * angularSmoothTime);
    }
}
