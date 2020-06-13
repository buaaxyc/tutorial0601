using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyMinnow.SALSA.OneClicks
{
    public class BoxheadEyesRuntime : MonoBehaviour
    {
        private void Awake()
        {
            SkinnedMeshRenderer smr;
            Eyes eyes = gameObject.AddComponent<Eyes>();
            QueueProcessor queueProcessor = gameObject.AddComponent<QueueProcessor>();

            // System Properties
            eyes.AddParent(transform);
            eyes.characterRoot = transform.parent;
            eyes.queueProcessor = queueProcessor;

            // Heads - Bone_Rotation
            eyes.BuildHeadTemplate(Eyes.HeadTemplates.Bone_Rotation_XY);
            eyes.heads[0].expData.name = "head";
            eyes.heads[0].expData.components[0].name = "head";
            eyes.heads[0].expData.controllerVars[0].bone = eyes.transform;
            eyes.headTargetOffset.y = 1.4f;
            eyes.headRandDistRange = new Vector2(3, 3);
            //eyes.FixAllTransformAxes(ref eyes.heads, true);

            // Eyes - Blendshapes
            eyes.BuildEyeTemplate(Eyes.EyeTemplates.BlendShapes);
            eyes.RemoveExpression(ref eyes.eyes, 1);
            eyes.eyes[0].expData.name = "eyes";
            eyes.eyes[0].gizmo = eyes.CreateEyeGizmo("eyeGizmo", transform);
            eyes.eyes[0].gizmo.transform.position = transform.position;
            eyes.eyes[0].gizmo.transform.rotation = transform.rotation;
            eyes.eyes[0].gizmo.transform.parent = transform;
            eyes.eyes[0].gizmo.transform.localPosition = new Vector3(0f, 1.38f, 1f);
            eyes.eyes[0].gizmo.showGizmo = false;
            smr = eyes.GetComponent<SkinnedMeshRenderer>();
            eyes.eyes[0].expData.controllerVars[0].smr = smr;
            eyes.eyes[0].expData.controllerVars[0].blendIndex = 4; // up
            eyes.eyes[0].expData.controllerVars[1].smr = eyes.eyes[0].expData.controllerVars[0].smr;
            eyes.eyes[0].expData.controllerVars[1].blendIndex = 7; // right
            eyes.eyes[0].expData.controllerVars[2].smr = eyes.eyes[0].expData.controllerVars[0].smr;
            eyes.eyes[0].expData.controllerVars[2].blendIndex = 5; // down
            eyes.eyes[0].expData.controllerVars[3].smr = eyes.eyes[0].expData.controllerVars[0].smr;
            eyes.eyes[0].expData.controllerVars[3].blendIndex = 6; // left
            eyes.eyeRandTrackFov = new Vector3(0.5f, 0.3f, 0f);

            /*// Eyelids - Bone_Rotation
            eyes.BuildEyelidTemplate(Eyes.EyelidTemplates.BlendShapes);
            eyes.RemoveExpression(ref eyes.eyelids, 1);
            eyes.SetEyelidShapeSelection(Eyes.EyelidSelection.Upper);
            eyes.eyelidTracking = false;
            eyes.eyelids[0].expData.controllerVars[0].smr = smr;
            eyes.eyelids[0].expData.controllerVars[0].blendIndex = 8;*/

            // Update runtime controllers
            eyes.UpdateRuntimeExpressionControllers(ref eyes.heads);
            eyes.UpdateRuntimeExpressionControllers(ref eyes.eyes);
            //eyes.UpdateRuntimeExpressionControllers(ref eyes.eyelids);

            // Initialize the Eyes module
            eyes.Initialize();
        }
    }
}