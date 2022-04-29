using UnityEngine;
using Cinemachine;

[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] 
public class LockCameraY : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    public float ypos = 0f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = ypos;
            state.RawPosition = pos;
        }
    }
}
