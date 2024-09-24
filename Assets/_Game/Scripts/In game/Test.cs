using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.Utils;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector3 center, dir;
    [SerializeField] private Transform targetPos;
    [SerializeField] private float angle;

    private Vector3 originalPos;

    private void Awake(){
        originalPos = transform.position;
    }
    [Sirenix.OdinInspector.Button]
    private void TestRotate(){
        var pos = transform.position;
        transform.position = VectorUtils.RotatePointAround(pos, center, dir, angle);
    }

    private void Update(){
        this.TestInterpolate();
    }
    private void TestInterpolate(){
        transform.position = VectorUtils.CircularInterpolate(transform.position, targetPos.position, center, dir, Time.deltaTime);
    }
}
