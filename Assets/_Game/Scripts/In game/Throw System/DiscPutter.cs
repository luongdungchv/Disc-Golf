using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DL.Utils;
using UnityEngine;

public class DiscPutter : DiscThrower
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private float releaseDist, spdMultiplier;
    [SerializeField] private GameObject dummyObj;
    private bool dragging;
    private Vector3 oldDiscPos;
    private Camera mainCam => CameraFollow.Instance.GetComponent<Camera>();

    private void Start()
    {
        oldDiscPos = this.discObj.transform.position;
    }

    [Sirenix.OdinInspector.Button]
    private void TestRaycast()
    {
        Debug.Log(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, 1000));
    }


    private void Update()
    {
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray.origin, ray.direction, 1000, mask))
            {
                dragging = true;
                Debug.Log("asds");
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (dragging)
            {
                var dragPoint = MathUtils.GetIntersectionWithPlane(
                    ray.origin,
                    ray.direction,
                    this.discObj.transform.up,
                    ThrowStateController.Instance.Aimer.transform.position
                );
                this.discObj.transform.position = dragPoint;
                //dummyObj.transform.position = dragPoint;
                Debug.Log(dragPoint);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (dragging)
            {
                dragging = false;
                var vel = (this.discObj.transform.position - oldDiscPos) / Time.deltaTime;
                this.discObj.StartPuttFlying(vel);
            }
        }
        var distToOrigin = Vector3.Distance(this.discObj.transform.position, ThrowStateController.Instance.Aimer.transform.position);
        if (dragging && distToOrigin >= this.releaseDist)
        {
            var vel = (this.discObj.transform.position - oldDiscPos) / Time.deltaTime * spdMultiplier;
            Debug.Log(vel.magnitude);
            this.discObj.StartPuttFlying(vel);
            dragging = false;
            
        }
        this.oldDiscPos = this.discObj.transform.position;
    }
}
