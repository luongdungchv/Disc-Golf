using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscThrower : MonoBehaviour
{
    [SerializeField] private Disc discObj;
    [SerializeField] private DiscAimer aimer;

    [SerializeField] private int curlDir = 1;
    [SerializeField] private int bend;

    private void Start(){
        this.Init();
    }

    public void SetCurlDirection(int dir){
        this.curlDir = dir;
    }

    public void Init(){
        this.discObj.StopFlying();
        discObj.transform.SetParent(aimer.transform);
        aimer.transform.position = this.transform.position;
        discObj.transform.localPosition = Vector3.zero;
        discObj.transform.localEulerAngles = Vector3.zero;


    }  
    public void Throw(){
        this.discObj.StartFlying(aimer.Direction, this.curlDir);
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space)){
            this.Throw();
        }
        else if(Input.GetKey(KeyCode.S)){
            this.Init();
        }

        this.discObj.Bend(this.bend);
    }  
}
