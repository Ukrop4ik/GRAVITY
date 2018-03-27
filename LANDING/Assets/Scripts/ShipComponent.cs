using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{

    public GameObject _obj;
    public float _HP;
    public string _id;

    private void Start()
    {
        _obj = this.gameObject;
    }

    public void Damage(float value)
    {
        _HP -= value;
        if (_HP <= 0)
        {
            gameObject.AddComponent<Rigidbody>();
            transform.SetParent(null);
        }
    }
}
