﻿using ArdNet;
using System.Collections;
using System.Collections.Generic;
using TankSim;
using TankSim.TankSystems;
using UnityEngine;

public class GunTarget : MonoBehaviour
{
    private const float _movementSpeed = 20;
    private const float _maxDistance = 10;
    private const float _minDistance = 1;

    private MovementDirection _currentDirection;

    private Tank _tank;


    private Vector3 _smallCircle = new Vector3(2, 2, 1);
    private Vector3 _bigCircle = new Vector3(6, 6, 1);

    private int _damage = 10;

    private bool _isSmallTarget = true;


    public DamageCircle DamageCirclePrefab;


    //server thread to game thread
    private PrimaryWeaponFireState _weaponsState;


    // Start is called before the first frame update
    void Start()
    {
        _tank = FindObjectOfType<Tank>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((_currentDirection & MovementDirection.North) == MovementDirection.North)
        {
            transform.localPosition += Vector3.up * _movementSpeed * Time.deltaTime;
            if (transform.localPosition.magnitude > _maxDistance)
            {
                transform.localPosition = Vector3.up * _maxDistance;
            }
        }
        else if ((_currentDirection & MovementDirection.South) == MovementDirection.South)
        {
            transform.localPosition -= Vector3.up * _movementSpeed * Time.deltaTime;
            if (transform.localPosition.magnitude < _minDistance)
            {
                transform.localPosition = Vector3.up * _minDistance;
            }
        }
    }


    public void ChangeAimDistance(MovementDirection moveDir)
    {
        _currentDirection = moveDir;
        
    }

    private void FireWeapon()
    {
        if (_weaponsState == PrimaryWeaponFireState.Misfire)
        {
            _tank.DamageTank(10);
        }
        else if (_weaponsState == PrimaryWeaponFireState.Valid)
        {
            SpawnDamageCircle();
        }
        
    }

    private void ChangeSize()
    {
        if (_isSmallTarget)
        {
            transform.localScale = _bigCircle;
            _damage = 3;
        }
        else
        {
            transform.localScale = _smallCircle;
            _damage = 10;
        }

        _isSmallTarget = !_isSmallTarget;
    }


    public void PrimaryFire(IConnectedSystemEndpoint c, PrimaryWeaponFireState state)
    {
        _weaponsState = state;
        UnityMainThreadDispatcher.Instance().Enqueue(FireWeapon);
    }

    public void ChangeAmmo(IConnectedSystemEndpoint c)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(ChangeSize);
    }


    private void SpawnDamageCircle()
    {
        DamageCircle newCircle = Instantiate(DamageCirclePrefab, transform.position, Quaternion.identity);
        newCircle.transform.localScale = transform.localScale;
        newCircle.SetDamage(_damage);
    }
}
