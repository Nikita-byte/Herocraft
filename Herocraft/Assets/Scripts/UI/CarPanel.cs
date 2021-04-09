using UnityEngine.UI;
using UnityEngine;


public class CarPanel : MonoBehaviour
{
    [SerializeField] private Button _car1;
    [SerializeField] private Button _car2;

    public Button Car1Button { get { return _car1; } }
    public Button Car2Button { get { return _car2; } }
}
