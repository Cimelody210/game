using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    [SerializeField]
    private AudioClip fireSound;

    private AudioSource audioSource;

    private float _originalTimeBetweenShots;
    private bool _isRifleCollected = false;

    private int _bulletsFired = 0;
    private int _maxBullets = 40;
    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        _originalTimeBetweenShots = _timeBetweenShots;
    }
    void Update()
    {
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            // Kiểm tra nếu thời gian giữa các lần bắn đạt mức yêu cầu
            if (timeSinceLastFire >= _timeBetweenShots)
            {
                // Nếu có súng rifle và đã bắn hết đạn, khôi phục tốc độ bắn ban đầu và bỏ giới hạn đạn
                if (_isRifleCollected && _bulletsFired >= _maxBullets)
                {
                    // Khôi phục tốc độ bắn ban đầu
                    _timeBetweenShots = _originalTimeBetweenShots;
                    // Xóa giới hạn đạn (đặt lại giá trị tối đa của kiểu int)
                    _maxBullets = int.MaxValue;
                }

                FireBullet();

                _lastFireTime = Time.time;
                _fireSingle = false;
            }
        }
    }
    public bool HasRifle()
    {
        return _isRifleCollected;
    }

    public int GetRemainingAmmo()
    {
        return _maxBullets - _bulletsFired;
    }
    private void FireBullet()
    {
        // Kiểm tra nếu còn đạn thì bắn (hoặc nếu chưa nhặt súng rifle)
        if (!_isRifleCollected || (_isRifleCollected && _bulletsFired < _maxBullets))
        {
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

            rigidbody.velocity = _bulletSpeed * transform.up;

            audioSource.PlayOneShot(fireSound);

            _bulletsFired++;
        }
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }
    //-> RifleCollectable để đặt tốc độ bắn mới và giới hạn đạn
    public void SetRifleProperties(float newTimeBetweenShots, int maxBullets)
    {
        // Đánh dấu là đã nhặt súng rifle
        _isRifleCollected = true;
        // Đặt tốc độ bắn và giới hạn đạn mới
        _timeBetweenShots = newTimeBetweenShots;
        _maxBullets = maxBullets;
        // Đặt lại số đạn đã bắn là 0
        _bulletsFired = 0;
    }
}
