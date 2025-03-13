using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace RegularPolygons.Core
{
   
    public class PolygonShape : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        [Tooltip("Reference to its sprite renderer to change random color.")]
        SpriteRenderer spriteRenderer;

        [field:SerializeField]
        [Tooltip("Reference to the polygon collider to check if a click is within its bounds.")]
        public PolygonCollider2D PolygonCollider { get; private set; }

        [SerializeField]
        AudioSource audioSourceClickEffect;

        [Header("Animation Tweaks")]
        [SerializeField]
        [Range(0, 1)]
        float duration = .3f;

        [SerializeField]
        Ease ease = Ease.InOutQuad;

        [Header("Properties")]
        [SerializeField]
        Vector3 initialLocalScale = Vector3.one;

        private void Awake()
        {
            initialLocalScale = transform.localScale;
        }

        private void OnEnable()
        {
            DoubleClickManager.OnPolygonShapeDoubleClicked += DoubleClickManager_OnPolygonShapeDoubleClicked;
        }
        private void OnDisable()
        {
            DoubleClickManager.OnPolygonShapeDoubleClicked -= DoubleClickManager_OnPolygonShapeDoubleClicked;
        }

        private void DoubleClickManager_OnPolygonShapeDoubleClicked(PolygonShape poly)
        {
            if (poly != this)
                return;

            DoubleClick();            
        }      

        void DoubleClick()
        {
            audioSourceClickEffect?.Play();
            ChangeColor();
            Respawn();
        }
        void Respawn()
        {
            transform.DOScale(Vector3.zero, duration)
                .SetEase(ease)
                .OnComplete(() =>
                {
                    RepositionWithinBounds();
                    transform.DOScale(initialLocalScale, duration).SetEase(ease);
                });            
        }
        void ChangeColor()
        {
            spriteRenderer.sharedMaterial.color = new Color(Random.value, Random.value, Random.value);
        }

        void RepositionWithinBounds()
        {
            if (Camera.main == null)
            {
                Debug.LogError("Main Camera is not assigned or not found!");
                return;
            }

            if (spriteRenderer == null || spriteRenderer.sprite == null)
            {
                Debug.LogError("SpriteRenderer or sprite is not assigned!");
                return;
            }

            // Get the sprite's native size in pixels
            Vector2 spriteNativeSize = spriteRenderer.sprite.rect.size;

            // Convert to world units (assuming the sprite's pixels per unit is set correctly)
            float pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;
            Vector3 spriteSize = new Vector3(spriteNativeSize.x / pixelsPerUnit, spriteNativeSize.y / pixelsPerUnit, 1f);

            // Scale by the transform's scale
            spriteSize.x *= transform.localScale.x;
            spriteSize.y *= transform.localScale.y;

            // Get the camera's orthographic size and aspect ratio
            float camHeight = Camera.main.orthographicSize * 2f;
            float camWidth = camHeight * Camera.main.aspect;

            // Calculate the edges based on the camera bounds
            float halfSpriteWidth = spriteSize.x / 2f;
            float halfSpriteHeight = spriteSize.y / 2f;

            // Calculate the bounds within which the object can be positioned
            float minX = -camWidth / 2f + halfSpriteWidth;
            float maxX = camWidth / 2f - halfSpriteWidth;
            float minY = -camHeight / 2f + halfSpriteHeight;
            float maxY = camHeight / 2f - halfSpriteHeight;

            // Generate a random position within the bounds
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // Get the current Z position of the object
            float currentZ = transform.position.z;

            // Set the new position
            transform.position = new Vector3(randomX, randomY, currentZ);
        }
    }
}