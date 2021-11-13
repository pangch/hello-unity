using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public bool IsRotating { get; private set; }

    AnimationCurve rotationCurve;

    int rotationIndex = 0;
    Quaternion[] rotations = {
        new Quaternion(0, 0, 0, 1),
        new Quaternion(0, 0, -0.7071068f, -0.7071068f),
        new Quaternion(0, 0, -1, 0),
        new Quaternion(0, 0, -0.7071068f, 0.7071068f),
    };
    Quaternion rotationStart, rotationEnd;
    float rotationStartTime;

    // Update is called once per frame
    void Update()
    {
        if (IsRotating)
        {
            float fraction = rotationCurve.Evaluate((Time.time - rotationStartTime) * 0.8f);
            transform.rotation = Quaternion.Slerp(rotationStart, rotationEnd, fraction);
            if (fraction >= 1)
                IsRotating = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            IsRotating = true;
            rotationCurve = new AnimationCurve(
                new Keyframe(0, 0),
                new Keyframe(1, 1));
            rotationStart = rotations[rotationIndex];
            rotationIndex++;
            if (rotationIndex >= 4)
                rotationIndex = 0;
            rotationEnd = rotations[rotationIndex];
            rotationStartTime = Time.time;
        }
    }
}
