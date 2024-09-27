using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscThrower : MonoBehaviour
{
    [SerializeField] protected DiscAimer aimer;

    [SerializeField] protected float curl;
    [SerializeField] protected float throwStrength;
    protected CameraFollow cameraFollow => CameraFollow.Instance;

    public Disc Disc => DiscSelector.Instance.SelectedDisc;
    

    public void Init(){
        this.Disc.StopFlying();
        this.aimer.AttachCamera();

        Disc.transform.SetParent(aimer.transform);

        aimer.transform.position = this.transform.position;

        Disc.transform.localPosition = Vector3.zero;
        Disc.transform.localEulerAngles = Vector3.zero;
        
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
