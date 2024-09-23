using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscThrower : MonoBehaviour
{
    [SerializeField] private Disc discObj;
    [SerializeField] private DiscAimer aimer;
    [SerializeField] private CameraFollow cameraFollow;

    [SerializeField] private float curl;
    [SerializeField] private float throwStrength;

    public Disc Disc => this.discObj;
    private void Start(){
        //this.Init()    
    }

    public void Init(){
        this.discObj.StopFlying();
        this.aimer.AttachCamera();

        discObj.transform.SetParent(aimer.transform);

        aimer.transform.position = this.transform.position;

        discObj.transform.localPosition = Vector3.zero;
        discObj.transform.localEulerAngles = Vector3.zero;
        
        this.cameraFollow.SetFollow(false);
    }  
    public void Throw(){
        this.discObj.transform.SetParent(null);
        this.discObj.StartFlying(aimer.Direction, this.curl, this.throwStrength);
        this.aimer.DetachCamera();
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

    public void UIBendDragCallback(float dragLength, float hValue){
        this.curl = -hValue / dragLength;
        this.discObj.Bend(Mathf.Asin(hValue / dragLength) * Mathf.Rad2Deg);
        this.throwStrength = dragLength / 265;
    }
    public void UIBendDropCallback(){
        this.Throw();
    }
}
