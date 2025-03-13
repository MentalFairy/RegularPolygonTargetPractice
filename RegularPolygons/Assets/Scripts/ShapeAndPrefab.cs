using UnityEngine;

namespace RegularPolygons.Core
{
    /// <summary>
    /// I usually use Odin to serialize dictionaries straight into inspectors
    /// instead of using wrappers, but can't do that in a public repo :)
    /// </summary>
    [System.Serializable]
    public class ShapeAndPrefab
    {
        public PolygonShape PolygonShape;   
        public PolygonType PolygonType;
    }
}