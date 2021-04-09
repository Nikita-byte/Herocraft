using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.IO;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private UI _ui;
    [SerializeField] private CameraController _cameraController;

    private const string FOLDERNAME = "Score";
    private const string FILENAME = "Score";
    private string PATH;
    private CarController _carController;
    private TrackController _trackController;
    private Car _car;
    private Track _track;
    private float _score;
    private List<int> _scores;

    private void Start()
    {
        //LoadScore();

        UIInitialization();
        _gameState = GameState.Start;
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.Start:
                break;
            case GameState.Race:
                _carController.Execute();
                break;
            case GameState.Pause:
                break;
            case GameState.Finish:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (_gameState)
        {
            case GameState.Start:
                break;
            case GameState.Race:
                _carController.FixedExecute();
                break;
            case GameState.Pause:
                break;
            case GameState.Finish:
                break;
        }
    }

    private void UIInitialization()
    {
        _ui.MainMenu.NewGame.onClick.AddListener(delegate {
            _ui.OpenMenu(MenuType.CarMenu);
        });

        _ui.MainMenu.Score.onClick.AddListener(delegate {
            _ui.OpenMenu(MenuType.ScoreMenu);
        });

        _ui.Score.Cancel.onClick.AddListener(delegate {
            _ui.OpenMenu(MenuType.MainMenu);
        });

        _ui.EndPanel.Close.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("SampleScene");
        });

        _ui.OpenMenu(MenuType.MainMenu);

        EventTrigger eventTrigger = _ui.Car1Button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry enter = new EventTrigger.Entry();
        enter.eventID = EventTriggerType.PointerEnter;
        enter.callback.AddListener(delegate {
            _ui.Car1Button.gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
        });

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener(delegate {
            _ui.Car1Button.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        });

        _ui.Car1Button.onClick.AddListener(delegate {UseCarType(0); });

        EventTrigger eventTrigger1 = _ui.Car2Button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry enter1 = new EventTrigger.Entry();
        enter1.eventID = EventTriggerType.PointerEnter;
        enter1.callback.AddListener(delegate
        {
            _ui.Car2Button.gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
        });

        EventTrigger.Entry exit1 = new EventTrigger.Entry();
        exit1.eventID = EventTriggerType.PointerExit;
        exit1.callback.AddListener(delegate
        {
            _ui.Car2Button.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        });

        _ui.Car2Button.onClick.AddListener(delegate { UseCarType(1); });

        eventTrigger.triggers.Add(enter);
        eventTrigger.triggers.Add(exit);
        eventTrigger1.triggers.Add(enter1);
        eventTrigger1.triggers.Add(exit1);
    }

    private void ChangeCheckPoint(float Tpos, bool isInScore, bool IsEnd)
    {
        if (isInScore)
        {
            _score += 100;
            _ui.TextTable.SetScore(_score.ToString());
        }

        if (IsEnd)
        {
            _gameState = GameState.Finish;
            _ui.EndPanel.Score.text = _score.ToString();
            _ui.OpenMenu(MenuType.EndPanel);
            //ChangeScore();
        }

        _carController.SetPoint(Tpos);
    }

    private void UseCarType(int i)
    {
        _ui.OpenMenu(MenuType.OffMenu);
        _score = 0;
        _gameState = GameState.Race;

        ObjectPool.Instance.Initialize();
        _track = ObjectPool.Instance.GetRandomMap().GetComponent<Track>();
        _car = ObjectPool.Instance.GetRandomCar().GetComponent<Car>();
        _trackController = new TrackController(_track, _ui);
        _carController = new CarController(_car, _trackController, _ui);
        _carController.width = _cameraController.gameObject.GetComponent<Camera>().pixelWidth;
        _cameraController.target = _car.transform;

        var points = _track._checkPoints;
        foreach (CheckPoint check in points)
        {
            check.CheckPointHandler += ChangeCheckPoint;
        }

        ChangeCheckPoint(0.21f, false, false);
    }

    public void ChangeScore()
    {
        var asfasfa = _ui.TextTable._score.text;
        var dfsfsdfsdfsdf = int.Parse(_ui.TextTable._score.text);
        _scores.Add(int.Parse(_ui.TextTable._score.text));

        _scores.Sort();

        _ui.Score._1.text = _scores[0].ToString();
        _ui.Score._2.text = _scores[1].ToString();
        _ui.Score._3.text = _scores[2].ToString();
        _ui.Score._4.text = _scores[3].ToString();
        _ui.Score._5.text = _scores[4].ToString();
        _ui.Score._6.text = _scores[5].ToString();
        _ui.Score._7.text = _scores[6].ToString();
        _ui.Score._8.text = _scores[7].ToString();
        _ui.Score._9.text = _scores[8].ToString();
        _ui.Score._10.text = _scores[9].ToString();

        string json = JsonUtility.ToJson(_ui.Score);
        File.WriteAllText(Path.Combine(PATH, FILENAME), json);
    }

    public void LoadScore()
    {
        PATH = Path.Combine(Application.dataPath, FOLDERNAME);

        if (!Directory.Exists(Path.Combine(PATH)))
        {
            Directory.CreateDirectory(PATH);

            string json = JsonUtility.ToJson(_ui.Score);
            File.WriteAllText(Path.Combine(PATH, FILENAME), json);
        }

        var score = File.ReadAllText(Path.Combine(PATH, FILENAME));
        JsonUtility.FromJsonOverwrite(score, _ui.Score);

        _scores = new List<int>();
        var asdad = _ui.Score._1.text;

        _scores.Add(int.Parse(_ui.Score._1.text));
        _scores.Add(int.Parse(_ui.Score._1.text));
        _scores.Add(int.Parse(_ui.Score._3.text));
        _scores.Add(int.Parse(_ui.Score._4.text));
        _scores.Add(int.Parse(_ui.Score._5.text));
        _scores.Add(int.Parse(_ui.Score._6.text));
        _scores.Add(int.Parse(_ui.Score._7.text));
        _scores.Add(int.Parse(_ui.Score._8.text));
        _scores.Add(int.Parse(_ui.Score._9.text));
        _scores.Add(int.Parse(_ui.Score._10.text));

        _scores.Sort();

        _ui.Score._1.text = _scores[0].ToString();
        _ui.Score._2.text = _scores[1].ToString();
        _ui.Score._3.text = _scores[2].ToString();
        _ui.Score._4.text = _scores[3].ToString();
        _ui.Score._5.text = _scores[4].ToString();
        _ui.Score._6.text = _scores[5].ToString();
        _ui.Score._7.text = _scores[6].ToString();
        _ui.Score._8.text = _scores[7].ToString();
        _ui.Score._9.text = _scores[8].ToString();
        _ui.Score._10.text = _scores[9].ToString();
    }
}
