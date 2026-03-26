using System;
using UnityEngine;

namespace Input
{
    public class InputButtons : MonoBehaviour
    {
        [SerializeField] private ButtonDirection _up;
        [SerializeField] private ButtonDirection _down;
        [SerializeField] private ButtonDirection _left;
        [SerializeField] private ButtonDirection _rigth;

        public Action<Vector3> ButtonActivated;

        private void OnEnable()
        {
            _up.OnChange += Activate;
            _down.OnChange += Activate;
            _left.OnChange += Activate;
            _rigth.OnChange += Activate;
        }

        private void OnDisable()
        {
            _up.OnChange -= Activate;
            _down.OnChange -= Activate;
            _left.OnChange -= Activate;
            _rigth.OnChange -= Activate;
        }

        private void Activate(Vector3 direction)
        {
            ButtonActivated?.Invoke(direction);
        }
    }
}