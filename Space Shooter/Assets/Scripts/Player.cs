﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float _speedMultiplier = 2f;
    [Header("Lasers")]
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _shield;

    [Header("FireRates")]
    [SerializeField]
    private float _fireRate = 0.3f;
    private float _canFire = -1f;

    [Header("Lives")]
    [SerializeField]
    private int _lives = 3;
    SpawnManager spawnManager;

    [Header("Bools")]
    [SerializeField]
    bool _IsTripleShotActive = false;
    [SerializeField]
    bool _IsSpeedBoostActive = false;
    [SerializeField]
    private bool _IsShieldActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.FindGameObjectWithTag("SM").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot();
        }
    }

    public void Damage()
    {
        if (_IsShieldActive)
        {
            StartCoroutine(DeactivateShield());
            return;
        }

        _lives--;

        if (_lives < 1)
        {
            if(spawnManager != null)
            {
                spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }

        }
    }

    public void ActivateShield()
    {
        _IsShieldActive = true;
        _shield.SetActive(true);
    }

    private IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(1);
        _IsShieldActive = false;
        _shield.SetActive(false);
    }


    public void ActivateTripleShot()
    {
        _IsTripleShotActive = true;
        StartCoroutine(DeactivateTripleShot());
    }

    private IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(5);
        _IsTripleShotActive = false;
    }

    public void ActivateSpeedIncrease()
    {
        _IsSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(DecreaseSpeed());
    }

    private IEnumerator DecreaseSpeed()
    {
        yield return new WaitForSeconds(5);
        _IsSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }


    void Shoot()
    {
            //_canFIre = CurrentTIme player + the fireRate. Every time that the space key is pressed the canfire variable is set ot the new time that it can fire
            _canFire = Time.time + _fireRate;
        if (!_IsTripleShotActive)
        {
            Instantiate(_laser, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }else if (_IsTripleShotActive)
        {
            Instantiate(_tripleShot, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        }

            
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //limit movement between two positions
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0f), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, transform.position.z);
        }
    }



}
