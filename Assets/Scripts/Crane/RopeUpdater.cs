using UnityEngine;

namespace Crane
{
    public class RopeUpdater : MonoBehaviour
    {
        [SerializeField] private LineRenderer _line;
        [SerializeField] private Transform _attachmentPoint1;
        [SerializeField] private Transform _attachmentPoint2;

        private void OnGUI()
        {
            _line.SetPosition(0, _attachmentPoint1.position);
            _line.SetPosition(1, _attachmentPoint2.position);
        }
    }
}