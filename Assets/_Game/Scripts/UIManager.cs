using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button signInBtn;

    private void Awake(){
        signInBtn.onClick.AddListener(AuthenticationManager.Instance.SignInWithGoogle);
    }
}
