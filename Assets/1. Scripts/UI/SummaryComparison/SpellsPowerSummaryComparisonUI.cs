using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellsPowerSummaryComparisonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _damageCells;
    [SerializeField] private TMP_Text[] _protectionCells;
    [SerializeField] private TMP_Text[] _healCells;
    [SerializeField] private TMP_Text[] _repeatingCells;


    [SerializeField] private float[,] _matrix = new float[4, 4];

    public void Initialize()
    {
        Calculate();
        Fill();
    }

    public void Calculate()
    {
        _matrix[0, 0] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyDamage;
        _matrix[0, 1] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyProtection;
        _matrix[0, 2] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyHeal;
        _matrix[0, 3] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyDamage;

        _matrix[1, 0] = SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyDamage;
        _matrix[1, 1] = SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyProtection;
        _matrix[1, 2] = SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyHeal;
        _matrix[1, 3] = SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyProtection;

        _matrix[2, 0] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyDamage;
        _matrix[2, 1] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyProtection;
        _matrix[2, 2] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyHeal;
        _matrix[2, 3] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyHeal;

        _matrix[3, 0] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyDamage;
        _matrix[3, 1] = SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyProtection;
        _matrix[3, 2] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyHeal;
        _matrix[3, 3] = 0;
    }

    public void Fill()
    {
        for (int i = 0; i < _damageCells.Length; i++)
        {
            _damageCells[i].text = _matrix[0, i].ToString();
        }
        for (int i = 0; i < _protectionCells.Length; i++)
        {
            _protectionCells[i].text = _matrix[1, i].ToString();
        }
        for (int i = 0; i < _healCells.Length; i++)
        {
            _healCells[i].text = _matrix[2, i].ToString();
        }
        for (int i = 0; i < _repeatingCells.Length; i++)
        {
            _repeatingCells[i].text = _matrix[3, i].ToString();
        }
    }


}
