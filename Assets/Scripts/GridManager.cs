using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _heigh;
    [SerializeField] private Tile _tile;
    [SerializeField] private Transform _cam;
    void Start()
    {
        GenerateGrid(); 
    }
    void GenerateGrid() { 
    for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _heigh; y++)
            {
                var tile = Instantiate(_tile, new Vector3(x, y, 0), Quaternion.identity);
                tile.name=$"Tile {x} {y}";

                var isOffset=(x%2 == 0 && y%2 != 0)||(x%2 != 0 && y%2 == 0);
               // tile.Init(isOffset);
            }
        }
        _cam.transform.position =new Vector3((float) _width/2 -0.5f, (float) _heigh/ 2 -0.5f,-10);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
