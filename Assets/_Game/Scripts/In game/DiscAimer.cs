using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscAimer : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Transform camHolder;
    [SerializeField] private Vector2 verticalRotationLimit;

    private Camera mainCam;

    private void Awake(){
        mainCam = Camera.main;
    }

    public void Rotate(Vector2 dragVector){
        var angleX = dragVector.y;
        var angleY = dragVector.x;

        var currentRot = transform.eulerAngles;
        currentRot.y += angleY * sensitivity;

        if(currentRot.x > 180)
            currentRot.x -= 360;
        currentRot.x -= angleX * sensitivity;
        currentRot.x = Mathf.Clamp(currentRot.x, verticalRotationLimit.x, verticalRotationLimit.y);

        transform.eulerAngles = currentRot;
    }

    public void DetachCamera(){
        this.mainCam.transform.SetParent(null);
    }

    public void AttachCamera(){
        this.mainCam.transform.position = camHolder.position;
        this.mainCam.transform.rotation = camHolder.rotation;
        this.mainCam.transform.SetParent(this.transform);
    }
}
