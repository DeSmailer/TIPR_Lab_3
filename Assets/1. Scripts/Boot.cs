using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
    [SerializeField] private SpellsData _spellsData;
    [SerializeField] private UI _UI ;

    private void Awake()
    {
        _spellsData.Initialize();
        _UI.Initialize();
    }
}
