using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {


    public Text _fuelText;
    public Text _distText;
    public Text _altutude;
    public Text _speed;




    private GameController _game;


    private void Start()
    {
        _game = GameController.Instance();
    }

    private void Update()
    {
        _fuelText.text = "FUEL: " + _game.GetFuel().ToString("0");
        _distText.text = "MAXDIST: " + _game.GetMaxDist().ToString("0");
        _speed.text = "SPEED: " + _game.GetSpeed().ToString("0");
        _altutude.text = "ALT: " + _game.GetAlt().ToString("0");
    }
}
