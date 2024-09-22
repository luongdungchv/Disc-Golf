using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disc : MonoBehaviour
{
    [SerializeField] private float initialSpd, initialAngularSpd;
    [SerializeField] private float curl;

    private bool isFlying;
    private int curlDir;

    private Vector3 flyingRightDir;

    private Rigidbody body => this.GetComponent<Rigidbody>();

    public void StartFlying(Vector3 direction, int curlDir){
        body.velocity = direction * initialSpd;
        body.angularVelocity = transform.up * initialAngularSpd * curlDir;
        body.useGravity = true;
        this.isFlying = true;
        this.curlDir = curlDir;

        this.flyingRightDir = transform.right;
    }

    public void StopFlying(){
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.useGravity = false;
        this.isFlying = false;
        this.curlDir = 0;
    }

    private void Update(){
        if(this.isFlying){
            this.body.velocity += curl * curlDir * flyingRightDir * Time.deltaTime * this.body.velocity.magnitude;
        }
    }

    public void Bend(float angle){
        if(this.isFlying) return;
        var rotation = transform.eulerAngles;
        rotation.z = angle;
        transform.eulerAngles = rotation;
    }
}
