using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.Utils;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public void TestLoadScene(){
        SceneManager.LoadSceneAsync("Game_LakeSide");
    }
}
