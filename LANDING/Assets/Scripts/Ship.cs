using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    [SerializeField]
    private float _hullHP;
    [SerializeField]
    private GameController _game;
    [SerializeField]
    private List<ShipComponent> _elements = new List<ShipComponent>();
    [SerializeField]
    private Transform _componentRoot;

    private void Start()
    {
        _game = GameController.Instance();

        for(int i = 0; i < _componentRoot.childCount; i++)
        {
            _elements.Add(_componentRoot.GetChild(i).gameObject.GetComponent<ShipComponent>());
        }
    }

    void OnCollisionEnter(Collision col)
    {
        
        foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider.gameObject.tag == "Contact")
            {
                foreach(ShipComponent el in _elements)
                {
                    if (el == null) continue;

                    if(el._obj == contact.thisCollider.gameObject)
                    {
                        print(_game.GetShipBody().mass * _game.GetSpeed());
                        el.Damage(_game.GetShipBody().mass * _game.GetSpeed());
                        return;
                    }
                }
            }
        }
    } 


}
