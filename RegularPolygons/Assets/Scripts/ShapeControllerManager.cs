using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace RegularPolygons.Core
{
    public class ShapeControllerManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        TMP_Dropdown dropdownPolygonShapes;

        [SerializeField]
        List<ShapeAndPrefab> shapeAndPrefabList = new();

        [SerializeField]
        PolygonShape currentShape;

        public static event Action<PolygonShape> OnShapeChanged;

        private void Awake()
        {
            InitializeDropdown();
        }
        private void OnEnable()
        {
            dropdownPolygonShapes.onValueChanged.AddListener(OnShapeDropdownChanged);
        }
        private void OnDisable()
        {
            dropdownPolygonShapes.onValueChanged.RemoveListener(OnShapeDropdownChanged);
        }
        private void OnShapeDropdownChanged(int newValue)
        {
            Destroy(currentShape.gameObject);
            currentShape = Instantiate(shapeAndPrefabList[newValue].PolygonShape);

            //Overkill via Linq
            //currentShape = Instantiate(shapeAndPrefabList.FirstOrDefault(s=>s.PolygonType == (PolygonType)newValue).PolygonShape);

            OnShapeChanged?.Invoke(currentShape);
        }
      
        private void InitializeDropdown()
        {
            dropdownPolygonShapes.ClearOptions();
            List<string> newOptions = new();
            foreach (var shape in shapeAndPrefabList)
            {
                newOptions.Add(shape.PolygonType.ToString());
            }
            dropdownPolygonShapes.AddOptions(newOptions);
        }
    }
}
