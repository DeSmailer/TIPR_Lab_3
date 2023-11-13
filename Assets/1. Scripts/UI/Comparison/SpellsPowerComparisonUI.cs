using UnityEngine;

public class SpellsPowerComparisonUI : MonoBehaviour
{
    [SerializeField] private SpellsPowerComparisonCell[] _damageCells;
    [SerializeField] private SpellsPowerComparisonCell[] _protectionCells;
    [SerializeField] private SpellsPowerComparisonCell[] _healCells;
    [SerializeField] private SpellsPowerComparisonCell[] _repeatingCells;

    public void Initialize()
    {
        SpellsData.Instance.OnDataChange += Fill;

        Fill();
    }

    public void Fill()
    {
        _damageCells[0].FillText(SpellsData.Instance.MyDamage.ToString(), (-SpellsData.Instance.EnemyDamage).ToString());
        _damageCells[1].FillText(SpellsData.Instance.MyDamage.ToString(), (-SpellsData.Instance.EnemyProtection).ToString());
        _damageCells[2].FillText(SpellsData.Instance.MyDamage.ToString(), (-SpellsData.Instance.EnemyHeal).ToString());
        _damageCells[3].FillText(SpellsData.Instance.MyDamage.ToString(), (-SpellsData.Instance.EnemyDamage).ToString());

        _protectionCells[0].FillText(SpellsData.Instance.MyProtection.ToString(), (-SpellsData.Instance.EnemyDamage).ToString());
        _protectionCells[1].FillText(SpellsData.Instance.MyProtection.ToString(), (-SpellsData.Instance.EnemyProtection).ToString());
        _protectionCells[2].FillText(SpellsData.Instance.MyProtection.ToString(), (-SpellsData.Instance.EnemyHeal).ToString());
        _protectionCells[3].FillText(SpellsData.Instance.MyProtection.ToString(), (-SpellsData.Instance.EnemyProtection).ToString());

        _healCells[0].FillText(SpellsData.Instance.MyHeal.ToString(), (-SpellsData.Instance.EnemyDamage).ToString());
        _healCells[1].FillText(SpellsData.Instance.MyHeal.ToString(), (-SpellsData.Instance.EnemyProtection).ToString());
        _healCells[2].FillText(SpellsData.Instance.MyHeal.ToString(), (-SpellsData.Instance.EnemyHeal).ToString());
        _healCells[3].FillText(SpellsData.Instance.MyHeal.ToString(), (-SpellsData.Instance.EnemyHeal).ToString());

        _repeatingCells[0].FillText(SpellsData.Instance.MyDamage.ToString(), (-SpellsData.Instance.EnemyDamage).ToString());
        _repeatingCells[1].FillText(SpellsData.Instance.MyProtection.ToString(), (-SpellsData.Instance.EnemyProtection).ToString());
        _repeatingCells[2].FillText(SpellsData.Instance.MyHeal.ToString(), (-SpellsData.Instance.EnemyHeal).ToString());
        _repeatingCells[3].FillText("0", "0");
    }

    private void OnDestroy()
    {
        SpellsData.Instance.OnDataChange -= Fill;
    }
}
