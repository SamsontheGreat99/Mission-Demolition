using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingLine : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 launchPos = new Vector3(0, 0, 0);
    public float scale = .1f;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 MousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 slingshotFingersCrossed = new Vector3(MousePos3D.x * scale, MousePos3D.y * scale, MousePos3D.z * scale);
        //Vector3 MousePos3D = Camera.main.ScreenToViewportPoint(mousePos2D);
        //Vector3 slingshotFingersCrossed = MousePos3D;
        //Vector3 mouseDelta = MousePos3D - launchPos;
        //float maxMagnitude = GameObject.Find("Projectile(Clone)").GetComponent<SphereCollider>().radius;
        //if (mouseDelta.magnitude > maxMagnitude)
        //{
        //    mouseDelta.Normalize();
        //    mouseDelta *= maxMagnitude;
        //}

        //Vector3 projPos = launchPos + mouseDelta;

        line.SetPosition(1, slingshotFingersCrossed);
    }
}
