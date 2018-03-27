using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameController _game;
    private Transform _cameraTransform;
    private Transform _shipTransform;
    [SerializeField]
    private Vector3 _camOffset;
    private float _zOffset = 6f;
    private float _yBuffer;
    private void Start()
    {
        _game = GameController.Instance();
        _cameraTransform = Camera.main.transform;
        _shipTransform = _game.GetPlayership().transform;
        _yBuffer = _shipTransform.position.y;
    }

    private void Update()
    {
        _cameraTransform.position = new Vector3(_shipTransform.position.x + _camOffset.x, _shipTransform.position.y + _camOffset.y, _camOffset.z);

  
       if(_shipTransform.position.y != _yBuffer)
       {
            _zOffset = Mathf.Lerp(_zOffset, _shipTransform.position.y + 6, Time.deltaTime*2f);
            _zOffset = Mathf.Clamp(_zOffset, 6, 20);
        }
  
    }
}
