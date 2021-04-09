using UnityEngine;
using System.Collections.Generic;


public class ObjectPool
{
    private static ObjectPool _instance = new ObjectPool();

    private string MAP_PATH = "Maps";
    private string CAR_PATH = "Cars";
    private string POOL_NAME = "[ObjectPool]";
    private GameObject _objectPool;
    private List<GameObject> _maps;
    private List<GameObject> _cars;
    private System.Random _rand;

    public static ObjectPool Instance { get { return _instance; } }

    public void Initialize()
    {
        _objectPool = new GameObject(POOL_NAME);

        _maps = new List<GameObject>();
        _cars = new List<GameObject>();
        _rand = new System.Random();


        var maps = Resources.LoadAll(MAP_PATH);

        foreach (GameObject map in maps)
        {
            var go = GameObject.Instantiate(map, _objectPool.transform);
            go.SetActive(false);
            _maps.Add(go);
        }

        var cars = Resources.LoadAll(CAR_PATH);

        foreach (GameObject car in cars)
        {
            var go = GameObject.Instantiate(car, _objectPool.transform);
            go.SetActive(false);
            _cars.Add(go);
        }
    }

    public GameObject GetRandomMap()
    {
        var map = _maps[_rand.Next(0, _maps.Count)];
        map.SetActive(true);
        return map;
    }

    public GameObject GetRandomCar()
    {
        var car = _cars[_rand.Next(0, _cars.Count)];
        car.SetActive(true);
        return car;
    }
}
