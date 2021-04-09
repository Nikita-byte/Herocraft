using UnityEngine;
using UnityEngine.UI;


public sealed class UI : MonoBehaviour
{
    [SerializeField] private TextTable _textTable;
    [SerializeField] private CarPanel _carPanel;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private ScorePanel _scorePanel;
    [SerializeField] private EndPanel _endPanel;

    public TextTable TextTable { get { return _textTable; } }
    public Button Car1Button { get { return _carPanel.Car1Button; } }
    public Button Car2Button { get { return _carPanel.Car2Button; } }
    public MainMenu MainMenu { get { return _mainMenu; } }
    public ScorePanel Score { get { return _scorePanel; } }
    public EndPanel EndPanel { get { return _endPanel; } }

    public void OpenMenu(MenuType menu)
    {
        switch (menu)
        {
            case MenuType.MainMenu:
                _textTable.gameObject.SetActive(false);
                _carPanel.gameObject.SetActive(false);
                _mainMenu.gameObject.SetActive(true);
                _scorePanel.gameObject.SetActive(false);
                _endPanel.gameObject.SetActive(false);
                break;
            case MenuType.CarMenu:
                _textTable.gameObject.SetActive(false);
                _carPanel.gameObject.SetActive(true);
                _mainMenu.gameObject.SetActive(false);
                _scorePanel.gameObject.SetActive(false);
                _endPanel.gameObject.SetActive(false);
                break;
            case MenuType.ScoreMenu:
                _textTable.gameObject.SetActive(false);
                _carPanel.gameObject.SetActive(false);
                _mainMenu.gameObject.SetActive(false);
                _scorePanel.gameObject.SetActive(true);
                _endPanel.gameObject.SetActive(false);
                break;
            case MenuType.OffMenu:
                _textTable.gameObject.SetActive(true);
                _carPanel.gameObject.SetActive(false);
                _mainMenu.gameObject.SetActive(false);
                _scorePanel.gameObject.SetActive(false);
                _endPanel.gameObject.SetActive(false);
                break;
            case MenuType.EndPanel:
                _textTable.gameObject.SetActive(false);
                _carPanel.gameObject.SetActive(false);
                _mainMenu.gameObject.SetActive(false);
                _scorePanel.gameObject.SetActive(false);
                _endPanel.gameObject.SetActive(true);
                break;
        }
    }
}
