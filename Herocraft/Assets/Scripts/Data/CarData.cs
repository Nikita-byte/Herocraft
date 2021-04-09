using UnityEngine;


[CreateAssetMenu(fileName ="Settings",menuName ="Settings")]
public class CarData : ScriptableObject
{
    private static CarData _instance;

    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;
    public float SlowDeceleration;
    public float SpeedCoefficient;

    public static CarData Instance 
    { 
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<CarData>("Settings");
            }
            return _instance; 
        } 
    }
}
