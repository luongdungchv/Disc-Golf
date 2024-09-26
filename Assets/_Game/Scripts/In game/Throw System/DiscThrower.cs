using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscThrower : MonoBehaviour
{
    [SerializeField] protected Disc discObj;
    [SerializeField] protected DiscAimer aimer;

    [SerializeField] protected float curl;
    [SerializeField] protected float throwStrength;
    protected CameraFollow cameraFollow => CameraFollow.Instance;

    public Disc Disc => this.discObj;
    private void Start(){
        //this.Init()    
        Debug.Log(Vector3.Cross(Vector3.right, Vector3.forward));
        
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
    public virtual void Throw(){
        
    }

    [Sirenix.OdinInspector.Button]
    private void Test(){
        VectorUtils.Test<DiscThrower>();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space)){
            this.Throw();
        }
        else if(Input.GetKey(KeyCode.S)){
            this.Init();
        }
    }  
}
