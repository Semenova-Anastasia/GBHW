using System;
using UnityEngine;

namespace GeekBrains
{
	public class SelectionController : BaseController, IOnUpdate, IInitialization
	{
		private readonly Camera _mainCamera;
		private readonly Vector2 _center;
		private readonly float _dedicateDistance = 20;
		private GameObject _dedicatedObj;
		private ISelectObj _selectedObj;
		private bool _nullString;
		private bool _isSelectedObj;
        private SelectionObjMessageUi _selectionObjMessageUi;

        public void Init()
        {
            _selectionObjMessageUi = GameObject.FindObjectOfType<SelectionObjMessageUi>();
        }

        public SelectionController()
		{
			_mainCamera = Camera.main;
			_center = new Vector2(Screen.width / 2, Screen.height / 2);
		}

		public void OnUpdate()
		{
			if (Physics.Raycast(_mainCamera.ScreenPointToRay(_center), out var hit, _dedicateDistance))
			{
				SelectObject(hit.collider.gameObject);
				_nullString = false;
			}
			else if(!_nullString)
			{
                _selectionObjMessageUi.Text = String.Empty;
				_nullString = true;
				_dedicatedObj = null;
				_isSelectedObj = false;
			}
			if (_isSelectedObj)
			{
				// Действие над объектом
			}
		}

		private void SelectObject(GameObject obj)
		{
			if (obj == _dedicatedObj) return;
			_selectedObj = obj.GetComponent<ISelectObj>();
			if (_selectedObj != null)
			{
                _selectionObjMessageUi.Text = _selectedObj.GetMessage();
				_isSelectedObj = true;
			}
			else
			{
                _selectionObjMessageUi.Text = String.Empty;
				_isSelectedObj = false;
			}
			_dedicatedObj = obj;
		}
	}
}