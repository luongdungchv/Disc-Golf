using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button loadGameBtn;

    private void Awake()
    {
        loadGameBtn.onClick.AddListener(() =>
        {
            var loadParams = new LoadSceneParameters()
            {
                loadSceneMode = LoadSceneMode.Additive,
                localPhysicsMode = LocalPhysicsMode.Physics3D
            };
            Camera.main.gameObject.SetActive(false);
            SceneManager.LoadSceneAsync("Game_LakeSide", LoadSceneMode.Additive).completed += (op) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
                this.gameObject.SetActive(false);
            };

        });
    }
}
