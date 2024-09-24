using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Disc disc;
    [SerializeField] private float followMoveSpd, followAngularSpd;

    private bool isFollowing;

    public void Follow(){
        //if(!isFollowing) return;
        var pos = disc.CamFollowPosition;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * this.followMoveSpd);
        var targetRotation = Quaternion.LookRotation(disc.transform.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, followAngularSpd * Time.deltaTime);
        //transform.LookAt(target.transform, Vector3.up);
    }

    public void AdjustLookatTarget(Vector3 targetPos, Quaternion targetRot){
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, targetPos, Time.deltaTime * this.followMoveSpd), Quaternion.RotateTowards(transform.rotation, targetRot, followAngularSpd * Time.deltaTime));
    }

    public void SetFollow(bool state){
        this.isFollowing = state;
    }

    public void SetTarget(Disc target){
        this.disc = target;
    }
}
