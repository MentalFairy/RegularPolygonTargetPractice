using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RegularPolygons.Core
{
    public class DoubleClickManager : MonoBehaviour
    {
        public static event Action<PolygonShape> OnPolygonShapeDoubleClicked;

        [Header("References")]
        [SerializeField]
        PolygonShape polygonShape;

        [SerializeField]
        PlayerInput playerInput;

        [Header("Tweaksables")]
        [SerializeField]
        [Range(0f, 1f)]
        float clickThreshold = .3f;

        [Header("Properties")]
        [SerializeField]
        float lastClickTime;

        [SerializeField]
        Vector2 lastPosition;

        [Header("Input Actions")]
        [SerializeField] 
        InputActionReference tapAction;
        [SerializeField]
        InputActionReference moveAction;

        private void OnEnable()
        {
            ShapeControllerManager.OnShapeChanged += ShapeControllerManager_OnShapeChanged;
            tapAction.action.performed += TapAction;
            moveAction.action.performed += MoveAction;
        }
        private void OnDisable()
        {
            ShapeControllerManager.OnShapeChanged -= ShapeControllerManager_OnShapeChanged;
            tapAction.action.performed -= TapAction;
            moveAction.action.performed -= MoveAction;
        }

        private void MoveAction(InputAction.CallbackContext context)
        {          
            lastPosition = context.ReadValue<Vector2>();
        }

        private void TapAction(InputAction.CallbackContext obj)
        {
            if (Time.time - lastClickTime < clickThreshold)
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(lastPosition);
                if (polygonShape.PolygonCollider.OverlapPoint(worldPoint))
                {
                    OnPolygonShapeDoubleClicked?.Invoke(polygonShape);
                }
            }
            lastClickTime = Time.time;
        }
       
        private void ShapeControllerManager_OnShapeChanged(PolygonShape newShape)
        {
            polygonShape = newShape;
        }       
    }
}