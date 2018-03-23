using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private static GameController instance;
    public static GameController Instance() { return instance; }

    [SerializeField]
    private float _gravity;
    [SerializeField]
    private GameObject _playership;
    [SerializeField]
    private float _fuel;
    [SerializeField]
    private float _fuelMull;
    [SerializeField]
    private float _dist;
    [SerializeField]
    private float _maxdist;
    [SerializeField]
    private Vector3 _gravityVector;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _alt;

    [SerializeField]
    private Transform _planet;
    RaycastHit hit;
    [SerializeField]
    private LayerMask _mask;
    private Vector3 _startdot;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _startdot = _playership.transform.position;
        StartCoroutine(Speedometer());
    }

    private void Update()
    {
        GetDist();
    }

    private IEnumerator Speedometer()
    {
        Vector3 start;
        Vector3 end;

        start = _playership.transform.position;

        yield return new WaitForSeconds(0.1f);

        end = _playership.transform.position;

        _speed = Vector3.Distance(start, end) * 10f;
        StartCoroutine(Speedometer());
    }

    private void FixedUpdate()
    {
        SetGravityVector();
    }

    public float GetAlt()
    {

        if (Physics.Raycast(GetPlayership().transform.position, GetGravityVector(), out hit, _mask))
            _alt = Vector3.Distance(hit.point, GetPlayership().transform.position);

        return _alt;
    
    }


    public void SetGravityVector()
    {
        _gravityVector = _planet.transform.position - _playership.transform.position;
    }
    public Vector3 GetGravityVector()
    {
        return _gravityVector.normalized;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetGravity()
    {
       return _gravity;
    }
    public void SetGravity(float value = 0)
    {
        _gravity = value;
    }

    public float GetFuel()
    {
        return _fuel;
    }
    public void SetFuel(float value = 0)
    {
        _fuel = value;
    }

    public float GetFuelMull()
    {
        return _fuelMull;
    }
    public void SetFuelMull(float value = 0)
    {
        _fuelMull = value;
    }

    public GameObject GetPlayership()
    {
         return _playership;
    }
    public void SetPlayership(GameObject ship = null)
    {
        _playership = ship;
    }

    public float GetDist()
    {
        _dist = Vector3.Distance(_playership.transform.position, _startdot);

        return _dist;
    }

    public float GetMaxDist()
    {
        if (_dist > _maxdist)
            _maxdist = _dist;

        return _maxdist;
    }

}
