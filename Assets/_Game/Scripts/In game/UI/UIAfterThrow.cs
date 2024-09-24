using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAfterThrow : MonoBehaviour
{
    private ThrowStateController throwSystem;
    

    public void SetThrowSystem(ThrowStateController throwSystem){
        this.throwSystem = throwSystem;
    }
}
