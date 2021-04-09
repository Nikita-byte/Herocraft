using UnityEngine;
using UnityEngine.UI;


public class TextTable : MonoBehaviour
{
    [SerializeField] private Text _speed;
    [SerializeField] private Text _acceleration;
    [SerializeField] private Text _deceleration;
    [SerializeField] private Text _t;
    public Text _score;

    public void SetScore(string score)
    {
        _score.text =  score;
    }

    public void SetSpeed(string speed)
    {
        _speed.text = speed;
    }

    public void SetAcceleration(string accelereation)
    {
        _acceleration.text = "Acceleration : " + accelereation;
    }

    public void SetDeceleration(string deceleration)
    {
        _deceleration.text = "Deceleration : " + deceleration;
    }

    public void SetT(string T)
    {
        _t.text = "T : " + T;
    }
}
