using UnityEngine;
using TMPro;

public class SpellsPowerComparisonCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _my;
    [SerializeField] private TMP_Text _enemy;

    public void FillText(string my, string enemy)
    {
        _my.text = my;
        _enemy.text = enemy;
    }
}
