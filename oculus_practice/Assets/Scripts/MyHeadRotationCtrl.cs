/************************************************************************************
Filename    :   LipSyncDemo_Control.cs
Content     :   LipSync Demo controls
Created     :   July 11, 2018
Copyright   :   Copyright Facebook Technologies, LLC and its affiliates.
                All rights reserved.

Licensed under the Oculus Audio SDK License Version 3.3 (the "License");
you may not use the Oculus Audio SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

https://developer.oculus.com/licenses/audio-3.3/

Unless required by applicable law or agreed to in writing, the Oculus Audio SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeadRotationCtrl : MonoBehaviour
{

    [Tooltip("Key used to rotate the demo object up to 20 degrees to the left.")]
    public KeyCode rotateLeftKey = KeyCode.LeftArrow;
    [Tooltip("Key used to rotate the demo object up to 20 degrees to the right.")]
    public KeyCode rotateRightKey = KeyCode.RightArrow;
    [Tooltip("Key used to rotate the demo object up to 10 degrees to the right.")]
    public KeyCode rotateUpKey = KeyCode.UpArrow;
    [Tooltip("Key used to rotate the demo object up to 10 degrees to the right.")]
    public KeyCode rotateDownKey = KeyCode.DownArrow;
    [Tooltip("Key used to reset demo object rotation.")]
    public KeyCode resetRotationKey = KeyCode.Space;

    private float resetRotationLR = 90.0f;  //90.0f=target.transform.eulerAngles.y
    private float resetRotationUD = 257.1882f;  //257.1882f=target.transform.eulerAngles.z
    private float rotationAmount = 20.0f;
    private float rotationMaxLR = 20.0f;
    private float rotationMaxUD = 10.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rotateLeftKey))
        {
            RotateObject(rotationAmount, true);
        }
        else if (Input.GetKey(rotateRightKey))
        {
            RotateObject(-rotationAmount, true);
        }
        else if (Input.GetKey(rotateUpKey))
        {
            RotateObject(rotationAmount, false);
        }
        else if (Input.GetKey(rotateDownKey))
        {
            RotateObject(-rotationAmount, false);
        }
        else if (Input.GetKey(resetRotationKey))
        {
            RotateObject(0.0f, true, true);
        }
    }

    void RotateObject(float amountDegrees, bool isLR, bool absolute = false)
    {
        GameObject target = GameObject.Find("Bip01 Head");

        /*if (target == null)
        {
            // Try for other scene object
            target = GameObject.Find("RobotHead_TextureFlip");
        }*/

        if (target)
        {
            //Debug.Log("Find 'Bip01 Head'");
            if (absolute)
            {
                target.transform.rotation = new Quaternion(0, 0, 0, 0);

                //original code by Oculus
                /*float deltaRotateUD = resetRotationUD - target.transform.eulerAngles.z;
                target.transform.Rotate(Vector3.forward * deltaRotateUD);
                //Debug.Log("z:" + target.transform.eulerAngles.z);
                //Debug.Log("UD:" + deltaRotateUD);

                float deltaRotateLR = resetRotationLR - target.transform.eulerAngles.y;
                target.transform.Rotate(Vector3.left * deltaRotateLR);
                //Debug.Log("y:" + target.transform.eulerAngles.y);
                //Debug.Log("LR:" + deltaRotateLR);*/
            }
            else
            {
                float deltaRotate = Time.deltaTime * amountDegrees;
                if (isLR && deltaRotate + target.transform.eulerAngles.y >= resetRotationLR - rotationMaxLR &&
                    deltaRotate + target.transform.eulerAngles.y <= resetRotationLR + rotationMaxLR)
                {
                    target.transform.Rotate(Vector3.left * deltaRotate);
                }
                else if (!isLR && deltaRotate + target.transform.eulerAngles.z >= resetRotationUD - rotationMaxUD &&
                   deltaRotate + target.transform.eulerAngles.z <= resetRotationUD + rotationMaxUD)
                {
                    //Debug.Log("RotatingUD...");
                    target.transform.Rotate(Vector3.forward * deltaRotate);
                }
            }
        }
    }
}
