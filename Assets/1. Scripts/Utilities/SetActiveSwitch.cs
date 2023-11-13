using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    public void Switch()
    {
        if (_gameObject.activeInHierarchy)
        {
            _gameObject.SetActive(false);
        }
        else
        {
            _gameObject.SetActive(true);
        }
    }
}
