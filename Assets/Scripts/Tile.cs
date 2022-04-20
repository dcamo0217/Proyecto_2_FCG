using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public Color _basecolor,_offsetcolor;
    //[SerializeField] private SpriteRenderer _renderer;
    public GameObject Inner;
    //funcion start

    // Update is called once per frame
    public void SetColor(bool color)
    {
        if (color)
        {
            Inner.GetComponent<SpriteRenderer>().color = _basecolor;
        }
        else
        {
            Inner.GetComponent<SpriteRenderer>().color = _offsetcolor;
        }
    }
    public void EnemyColor()
    {
        Inner.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void HeroColor()
    {
        Inner.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
    
    




}