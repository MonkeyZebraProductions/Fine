using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform FollowTarget;
    public float FollowDistance,Speed;

    private float ms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lTargetDir = FollowTarget.position - transform.position;
        lTargetDir.y = 0.0f;

        Vector3 fromTarget = Vector3.ClampMagnitude(-lTargetDir.normalized, FollowDistance);
        Vector3 stopPoint = FollowTarget.position + fromTarget;


        float fastRadius = FollowDistance*5f;
        float speedBoost = 0.5f;

        float speedBlend = Mathf.Clamp01((Vector3.Distance(FollowTarget.position, transform.position) - FollowDistance) / (fastRadius - FollowDistance));

        ms = Speed + speedBlend * speedBoost;

        
            transform.position = Vector3.MoveTowards(transform.position, stopPoint, ms * Time.deltaTime);
        
        
    }
}
