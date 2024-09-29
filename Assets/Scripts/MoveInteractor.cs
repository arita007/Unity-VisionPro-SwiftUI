using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MoveInteractor : MonoBehaviour
{
    public GameLogic m_GameLogic;
    private bool _inMoving;
    private Vector3 _deltaPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var activeTouches = Touch.activeTouches;
        if (activeTouches.Count == 0)
        {
            ResetStatus();
        }
        else if (activeTouches.Count == 1)
        {
            DetectMove(activeTouches);
        }
    }

    private void ResetStatus()
    {
        _inMoving = false;
    }

    public void DetectMove(ReadOnlyArray<Touch> touches)
    {
        SpatialPointerState primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(touches[0]);

        GameObject objectBeingInteractedWith = primaryTouchData.targetObject;
        Vector3 interactionPosition = primaryTouchData.interactionPosition;

        if (objectBeingInteractedWith == null )
        {
            return;
            // MyLogger.Log(interactionPosition.ToString());
        }

        if (!_inMoving)
        {
            _inMoving = true;
            _deltaPos = objectBeingInteractedWith.transform.position - interactionPosition;
            return;
        }
        
        objectBeingInteractedWith.transform.position = interactionPosition + _deltaPos;
        m_GameLogic.UpdateInjectedSwiftUIPos(objectBeingInteractedWith.transform.position);

    }
}
