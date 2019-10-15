using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("in m/s")] [SerializeField] float xSpeed = 4f;
    [Tooltip("in m/s")] [SerializeField] float ySpeed = 4f;

    float xThrow, yThrow;

    [Tooltip("how far the ship can go left")] [SerializeField] float leftClamp = -3.5f;
    [Tooltip("how far the ship can go right")] [SerializeField] float rightClamp = 3.5f;

    [Tooltip("how far the ship can go down")] [SerializeField] float downClamp = -1.5f;
    [Tooltip("how far the ship can go up")] [SerializeField] float upClamp = 1.5f;

    [SerializeField] float positionPitchFactor = 5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlThrowFactor = -10f;
    [SerializeField] float controlRollFactor = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {

        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlThrowFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");//This gets a value between -1 and 1 depending on user input
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;//This gives us a value that is framerate independent and is modifiable in Unity
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float xNewPosition = xOffset + transform.localPosition.x;//Updates the x position of the ship each frame
        float yNewPosition = yOffset + transform.localPosition.y;

        xNewPosition = Mathf.Clamp(xNewPosition, leftClamp, rightClamp);//Forces the ship to stay between a set of values
        yNewPosition = Mathf.Clamp(yNewPosition, downClamp, upClamp);

        transform.localPosition = new Vector3(xNewPosition, yNewPosition, transform.localPosition.z);//LocalPosition is the position in terms of the parent object
    }
}
