using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    [SerializeField]
    private Transform _transform;
    private Rigidbody _body;
    [SerializeField]
    private GameObject _soplo;
    private GameController _game;

    private void Start()
    {
        _game = GameController.Instance();
        _body = _game.GetPlayership().GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            _soplo.SetActive(true);
        }
        else
            _soplo.SetActive(false);
           
    }

    private void FixedUpdate()
    {
        _body.AddForce(Vector3.up * -_game.GetGravity());

       // _body.AddForce(_game.GetGravityVector() * _game.GetGravity());


        if (_game.GetFuel() > 0 )
        {

                _body.AddForce(_transform.up * (Input.GetAxis("Vertical") * (_game.GetMaxAlt()/_game.GetAlt())));

                if (Input.GetAxis("Vertical") != 0)
                {
                    _game.SetFuel(_game.GetFuel() - _game.GetFuelMull());
                }
            

            _body.AddTorque(_transform.forward * -Input.GetAxis("Horizontal") * 2);
        }
    }
}
