using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Disc target;
    [SerializeField] private float followMoveSpd, followAngularSpd;

    private bool isFollowing;

    private void LateUpdate(){
        if(!isFollowing) return;
        var pos = target.CamFollowPosition;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * this.followMoveSpd);
        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, followAngularSpd * Time.deltaTime);
        //transform.LookAt(target.transform, Vector3.up);
    }

    public void SetFollow(bool state){
        this.isFollowing = state;
    }

    public void SetTarget(Disc target){
        this.target = target;
    }
}
