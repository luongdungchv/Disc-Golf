using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscThrower : MonoBehaviour
{
    [SerializeField] private Disc discObj;
    [SerializeField] private DiscAimer aimer;
    [SerializeField] private UIBender uiBender;
    [SerializeField] private CameraFollow cameraFollow;

    [SerializeField] private float curl;
    [SerializeField] private float throwStrength;

    private void Start(){
        this.Init();
        uiBender.RegisterOnDragCallback(this.UIBendDragCallback);
        uiBender.RegisterOnDropCallback(this.UIBendDropCallback);
    }

    public void Init(){
        this.discObj.StopFlying();
        discObj.transform.SetParent(aimer.transform);
        aimer.transform.position = this.transform.position;
        discObj.transform.localPosition = Vector3.zero;
        discObj.transform.localEulerAngles = Vector3.zero;
        this.cameraFollow.SetFollow(false);
    }  
    public void Throw(){
        this.discObj.transform.SetParent(null);
        this.discObj.StartFlying(aimer.Direction, this.curl, this.throwStrength);
        this.cameraFollow.SetFollow(true);
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space)){
            this.Throw();
        }
        else if(Input.GetKey(KeyCode.S)){
            this.Init();
        }

        //this.discObj.Bend(this.bend);
    }  

    private void UIBendDragCallback(float dragLength, float hValue){
        this.curl = -hValue / dragLength;
        this.discObj.Bend(Mathf.Asin(hValue / dragLength) * Mathf.Rad2Deg);
        this.throwStrength = dragLength / 265;
    }
    private void UIBendDropCallback(){
        this.Throw();
    }
}
