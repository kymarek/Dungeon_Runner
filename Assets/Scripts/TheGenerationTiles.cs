using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TheGenerationTiles : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxCount;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
   // [SerializeField] private List<Color> _colors = new List<Color> { Color.red, Color.blue, Color.green, Color.cyan };
    [SerializeField] private Transform _enviroment;


    void Start()
    {
        _tiles.First().speed = _speed;
        for (int i = 0; i < _maxCount; i++)
        {
            GenerateTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_tiles.Count < _maxCount)
        {
            GenerateTile();
        }
    }

    private void GenerateTile()
    { 
        GameObject newTileObject =  Instantiate(_tilePrefab, _tiles.Last().transform.position + Vector3.forward * _tiles.Last().transform.position.z, Quaternion.identity);
        Tile newTile = newTileObject.GetComponent<Tile>();
        newTile.speed= _speed;
        //newTile.transform.Find("Floor").GetComponent<Renderer>().material.SetColor("_Color", _colors[Random.Range(0, _colors.Count)]);
        _tiles.Add(newTile);
        newTileObject.transform.SetParent(_enviroment);

    }

    private void OnTriggerEnter(Collider other)
    {
        _tiles.Remove(other.GetComponent<Tile>());
        Destroy(other.gameObject);
    }
}
