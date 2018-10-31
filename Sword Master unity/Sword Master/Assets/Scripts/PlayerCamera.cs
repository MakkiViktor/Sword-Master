using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform lookAt;                    //Lookat of the camera
    public Transform target;                    //Target, wich around it rotates
    public float targetSizeViewportX = 1.0f;    //Size of the target in view space on x axis    
    public float targetSizeViewportY = 1.0f;    //Same on y axis    
    public float maxDistance = 5.0f;            //Maximum distance from the target

    public float sensivityX = 10.0f;            //Camera move speed on y
    public float sensivityY = 10.0f;            //Camera move speed on x
    public float YAngleMin = -50.0f;            //Min degree on Y    
    public float YAngleMax = 50.0f;             //Max degree on Y    

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float distance;
    private float rayDistance;
    private Vector3[] corners;
    private Vector3[] offsets;

    void Start()
    {
        corners = new Vector3[4];
        offsets = new Vector3[4];
        //Offset of the corners in target space
        offsets[0].Set(targetSizeViewportX, targetSizeViewportY, 0);
        offsets[1].Set(-targetSizeViewportX, targetSizeViewportY, 0);
        offsets[2].Set(targetSizeViewportX, -targetSizeViewportY, 0);
        offsets[3].Set(-targetSizeViewportX, -targetSizeViewportY, 0);
        distance = maxDistance;
        SetTransformation();
        //Sets the raycast distance
        rayDistance = (transform.rotation * offsets[0] + lookAt.position - (lookAt.position + maxDistance * transform.forward)).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Right Stick X") * sensivityX;
        currentY += Input.GetAxis("Right Stick Y") * sensivityY;
        currentY = Mathf.Clamp(currentY, YAngleMin, YAngleMax);
        distance = (transform.position - lookAt.position).magnitude;
        CalculateViewCorners();
        CheckCollision();
    }

    void LateUpdate()
    {
        SetTransformation();
    }

    //Sets up the new transformation of the camera
    void SetTransformation()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(lookAt.position);
    }

    //Calculates the new distance if there was an object between the lookat and the camera
    private void CheckCollision()
    {
        RaycastHit hitInfo;
        Vector3 hitPoint = new Vector3();
        float minDistance = rayDistance;
        bool hit = false;

        //Searches the nearest collision distance to the lookat
        foreach (var point in corners)
        {
            if (Physics.Raycast(point, transform.position - point, out hitInfo, rayDistance * 1.2f))
            {
                if (!(hitInfo.collider.tag == "Player"))
                    if (hitInfo.distance < minDistance)
                    {
                        minDistance = hitInfo.distance;
                        hitPoint = hitInfo.point;
                        hit = true;
                    }
            }
        }

        //Calculates the distance transformated for the camera forward axis
        if (hit)
        {
            Vector3 rayDir = (hitPoint - transform.position).normalized;
            float cosalpha = Vector3.Dot(rayDir, transform.forward);
            distance = Mathf.Abs(minDistance * cosalpha * 0.75f);
        }
        else distance = maxDistance * 0.75f;
    }

    //Calculates the corners
    private void CalculateViewCorners()
    {
        for (int i = 0; i < 4; i++)
        {
            corners[i] = transform.rotation * offsets[i] + lookAt.position;
        }
    }

    public float getXRotation() {
        return currentX;
    }
}

