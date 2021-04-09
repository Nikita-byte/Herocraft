using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _score;

    public Button NewGame { get { return _newGame; } }
    public Button Score { get { return _score; } }
}
