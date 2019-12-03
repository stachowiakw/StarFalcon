using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipController : MonoBehaviour
{
    [SerializeField] GameObject guns;
    // Start is called before the first frame update
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 15f;
    [SerializeField] float maxRangeLR = 5f;
    [SerializeField] float maxRangeUD = 4f;
    [SerializeField] float rotYawFactor = 7f;
    [SerializeField] float rotPitchPosFactor = 9f;
    [SerializeField] float rotPitchThrowFactor = 40f;
    [SerializeField] float rotRollThrowFactor = -40f;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {
        setYpos();
        setXpos();
        ProcessRotation();
        ProcessFire();
    }

    private void ProcessFire()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            guns.SetActive(true);
        }
        else
        {
            guns.SetActive(false);
        }
    }

    void setXpos()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffsetThisFrame, -maxRangeLR, maxRangeLR);
    
        //print(xOffsetThisFrame);
        transform.localPosition = new Vector3(rawNewXPos, transform.localPosition.y, transform.localPosition.z);
    }

    void setYpos()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = Mathf.Clamp(transform.localPosition.y + yOffsetThisFrame, -maxRangeUD, maxRangeUD);
       
        //print(yOffsetThisFrame);
        transform.localPosition = new Vector3(transform.localPosition.x, rawNewYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchFromPosition = -transform.localPosition.y * rotPitchPosFactor;
        float pitchFromTrust = yThrow * rotPitchThrowFactor;
        float yawFromPosition = transform.localPosition.x * rotYawFactor;
        float rollFromTrust = xThrow * rotRollThrowFactor;

        
        float pitch = pitchFromPosition - pitchFromTrust;
        float yaw = yawFromPosition;
        float roll = rollFromTrust;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
}
