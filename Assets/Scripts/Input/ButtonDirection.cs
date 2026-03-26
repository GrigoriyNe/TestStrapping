using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class ButtonDirection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Vector3 _direction;

        private bool _onDown;
        private float _eachInvokingSecond = 0.01f;
        private WaitForSeconds _waitInvoking;
        private Coroutine _invokingChange = null;

        public event Action<Vector3> OnChange;

        private void Start()
        {
            _waitInvoking = new WaitForSeconds(_eachInvokingSecond);
        }

        public void OnPointerDown(PointerEventData data)
        {
            _onDown = true;
            _invokingChange ??= StartCoroutine(Invoking());
        }

        public void OnPointerUp(PointerEventData data)
        {
            _onDown = false;
            _invokingChange = null;
        }

        private IEnumerator Invoking()
        {
            while (_onDown)
            {
                OnChange?.Invoke(_direction);
                yield return _waitInvoking;
            }
        }
    }
}