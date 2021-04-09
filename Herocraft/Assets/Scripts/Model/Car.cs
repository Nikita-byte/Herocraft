using UnityEngine;


public class Car : MonoBehaviour
{
    private float _maxSpeed;
    private float _acceleration;
    private float _deceleration;
    private float _slowDeceleration;
    private float _speed;

    private Rigidbody _rigidbody;

    public float Speed { get { return _speed; } }

    private void Awake()
    {
        _speed = 0;
        _maxSpeed = CarData.Instance.MaxSpeed; 
        _acceleration = CarData.Instance.Acceleration;
        _deceleration = CarData.Instance.Deceleration;
        _slowDeceleration = CarData.Instance.SlowDeceleration;

    _rigidbody = GetComponent<Rigidbody>();
    }

    public void Acceleration()
    {
        _speed += _acceleration;

        if (_speed > _maxSpeed)
        {
            _speed = _maxSpeed;
        }
    }

    public void Deceleration()
    {
        _speed -= _deceleration;

        if (_speed < 0)
        {
            _speed = 0;
        }
    }

    public void SlowDeceleration()
    {
        _speed -= _slowDeceleration;

        if (_speed < 0)
        {
            _speed = 0;
        }
    }

    public void Move(Vector3 _porposePoint)
    {
        transform.LookAt(_porposePoint);

        //_rigidbody.AddForce(transform.forward * _speed, ForceMode.Force);
        _rigidbody.velocity = transform.forward * _speed;
    }
}
