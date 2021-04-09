using UnityEngine;


public class CarController
{
    private Car _car;
    private TrackController _trackController;
    private UI _ui;
    private bool _isMoving;
    private Touch _touch;
    private Vector3 _nextPoint;
    public float width;

    public CarController(Car car, TrackController trackController, UI uI)
    {
        _isMoving = false;
        _car = car;
        _trackController = trackController;
        _car.gameObject.transform.position = _trackController.GetStartPonit().position;
        _car.gameObject.transform.rotation = _trackController.GetStartPonit().rotation;
        _ui = uI;
    }

    public void Execute()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _car.Acceleration();
            _isMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _car.Deceleration();
            _isMoving = false;
        }

        //if (Input.touchCount > 0)
        //{
        //    _touch = Input.GetTouch(0);

        //    if (_touch.position.x > width / 2)
        //    {
        //        _car.Acceleration();
        //        _isMoving = true;
        //    }
        //    else
        //    {
        //        _car.Deceleration();
        //        _isMoving = false;
        //    }
        //}

        _car.SlowDeceleration();
    }

    public void FixedExecute()
    {
        if (_isMoving)
        {
            _ui.TextTable.SetSpeed(_car.Speed.ToString());
            _car.Move(_trackController.GetPoint(_car.Speed));
        }

        //if (_isMoving)
        //{
        //    _ui.TextTable.SetSpeed(_car.Speed.ToString());
        //    _car.Move(_nextPoint);
        //}
    }

    public void SetPoint(float T)
    {
        _nextPoint = _trackController.GetPoint(T);
    }
}
