using UnityEngine;

namespace Crane
{
    public class CraneController : MonoBehaviour
    {
        [SerializeField] private float SpeedX;
        [SerializeField] private float SpeedY;

        [SerializeField] private SpringJoint _springJoint;
        [SerializeField] private Input.InputButtons _input;

        private void OnEnable()
        {
            _input.ButtonActivated += OnButtonPress;
        }

        private void OnDisable()
        {
            _input.ButtonActivated -= OnButtonPress;
        }

        private void OnButtonPress(Vector3 direction)
        {
            Vector3 currentDirection = new(
                direction.x * SpeedX,
                direction.y * SpeedY,
                0);

            if (direction.y != 0)
            {
                _springJoint.maxDistance -= currentDirection.y;
            }
            else
            {
                Vector3 target = transform.position + currentDirection;
                transform.position = target;
            }
        }
    }
}