using System;
using UnityEngine;

namespace RegularPolygons.Core
{
    public class DoubleClickManager : MonoBehaviour
    {
        public static event Action<PolygonShape> OnPolygonShapeDoubleClicked;

        [Header("References")]
        [SerializeField]
        PolygonShape polygonShape;

        [Header("Tweaksables")]
        [SerializeField]
        [Range(0f, 1f)]
        float clickThreshold = .3f;

        [Header("Properties")]
        [SerializeField]
        float lastClickTime;

        private void OnEnable()
        {
            ShapeControllerManager.OnShapeChanged += ShapeControllerManager_OnShapeChanged;
        }
        private void OnDisable()
        {
            ShapeControllerManager.OnShapeChanged -= ShapeControllerManager_OnShapeChanged;
        }
        private void ShapeControllerManager_OnShapeChanged(PolygonShape newShape)
        {
            polygonShape = newShape;
        }       

        void Update()
        {
            if (IsDoubleClick() || IsDoubleTap())
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (polygonShape.PolygonCollider.OverlapPoint(worldPoint))
                {
                    OnPolygonShapeDoubleClicked?.Invoke(polygonShape);
                }
            }
        }

        #region Private Methods

        /// <summary>
        /// Checks for desktop platforms if a double click has been registered within the time threshold.
        /// </summary>
        /// <returns>True, if double click is registered within threshold.</returns>
        bool IsDoubleClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastClickTime < clickThreshold) return true;
                lastClickTime = Time.time;
            }
            return false;
        }

        /// <summary>
        /// Checks for mobile platforms if a double click has been registered within the time threshold.
        /// </summary>
        /// <returns>True, if double click is registered within threshold.</returns>
        bool IsDoubleTap()
        {
            if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
            {
                if (Time.time - lastClickTime < clickThreshold) return true;
                lastClickTime = Time.time;
            }
            return false;
        }

        #endregion
    }
}