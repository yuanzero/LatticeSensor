using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.Subsystems;
using MixedReality.Toolkit;

public class HandFingersTrackingMRTK3 : MonoBehaviour
{
    public GameObject thumbObject;
    public GameObject indexObject;
    public GameObject middleObject;
    public GameObject ringObject;
    public GameObject pinkyObject;

    private HandsAggregatorSubsystem aggregator;


    void Start()
    {
        StartCoroutine(EnableWhenSubsystemAvailable());
    }

    IEnumerator EnableWhenSubsystemAvailable()
    {
        yield return new WaitUntil(() => XRSubsystemHelpers.GetFirstRunningSubsystem<HandsAggregatorSubsystem>() != null);
        aggregator = XRSubsystemHelpers.GetFirstRunningSubsystem<HandsAggregatorSubsystem>();
    }

    void Update()
    {
        if (aggregator == null) return;

        UpdateFingerPosition(TrackedHandJoint.ThumbTip, thumbObject);
        UpdateFingerPosition(TrackedHandJoint.IndexTip, indexObject);
        UpdateFingerPosition(TrackedHandJoint.MiddleTip, middleObject);
        UpdateFingerPosition(TrackedHandJoint.RingTip, ringObject);
        UpdateFingerPosition(TrackedHandJoint.LittleTip, pinkyObject);
    }

    void UpdateFingerPosition(TrackedHandJoint joint, GameObject fingerObject)
    {
        if (fingerObject == null) return;

        HandJointPose jointPose;
        if (aggregator.TryGetJoint(joint, XRNode.RightHand, out jointPose))
        {
            fingerObject.transform.position = jointPose.Position;
            // Optional: Adjust the rotation as well
            fingerObject.transform.rotation = jointPose.Rotation;
        }
    }
}
