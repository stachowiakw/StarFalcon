using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 15f;
    [SerializeField] float maxRangeLR = 6f;
    [SerializeField] float maxRangeUD = 4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setYpos();
        setXpos();
    }

    void setXpos()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffsetThisFrame, -maxRangeLR, maxRangeLR);

        print(xOffsetThisFrame);
        transform.localPosition = new Vector3(rawNewXPos, transform.localPosition.y, transform.localPosition.z);
    }

    void setYpos()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = Mathf.Clamp(transform.localPosition.y + yOffsetThisFrame, -maxRangeUD, maxRangeUD);

        print(yOffsetThisFrame);
        transform.localPosition = new Vector3(transform.localPosition.x, rawNewYPos, transform.localPosition.z);
    }
}
