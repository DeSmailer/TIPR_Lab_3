using UnityEngine;
using TMPro;
using System.Linq;

public class SpellsPowerSummaryComparisonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _damageCells;
    [SerializeField] private TMP_Text[] _protectionCells;
    [SerializeField] private TMP_Text[] _healCells;
    [SerializeField] private TMP_Text[] _repeatingCells;

    [SerializeField] private float[,] _matrix = new float[4, 4];

    //max из min справа, выбрать минимальные из него покрасить максимальное
    [SerializeField] private float[] _maxMin;
    //min из max снизу, выбрать максимальное из него покрасить минимальные
    [SerializeField] private float[] _minMax;

    [SerializeField] private MinMaxCell[] _maxMinCells;
    [SerializeField] private MinMaxCell[] _minMaxCells;

    //хорошо для нас зеленые справа и не красные снизу

    public void Initialize()
    {
        Fill();

        SpellsData.Instance.OnDataChange += Fill;
    }

    public void Calculate()
    {
        _matrix[0, 0] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyDamage;
        //_matrix[0, 1] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyProtection;
        _matrix[0, 1] = Mathf.Clamp(SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyProtection, 0, float.MaxValue);
        _matrix[0, 2] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyHeal;
        _matrix[0, 3] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyDamage;

        //_matrix[1, 0] = SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyDamage;
        _matrix[1, 0] = Mathf.Clamp(SpellsData.Instance.MyProtection - SpellsData.Instance.EnemyDamage, float.MinValue, 0);
        _matrix[1, 1] = 0;
        _matrix[1, 2] = 0 - SpellsData.Instance.EnemyHeal;
        _matrix[1, 3] = 0;

        _matrix[2, 0] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyDamage;
        _matrix[2, 1] = SpellsData.Instance.MyHeal - 0;
        _matrix[2, 2] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyHeal;
        _matrix[2, 3] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyHeal;

        _matrix[3, 0] = SpellsData.Instance.MyDamage - SpellsData.Instance.EnemyDamage;
        _matrix[3, 1] = 0;
        _matrix[3, 2] = SpellsData.Instance.MyHeal - SpellsData.Instance.EnemyHeal;
        _matrix[3, 3] = 0;
    }

    public void Fill()
    {
        Calculate();
        FillMatrix();

        FindMaxMin();
        FindMinMax();
        FillMinMax();
    }

    private void FillMatrix()
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

    private void FillMinMax()
    {
        float min = _minMax.Min(x => x);
        for (int i = 0; i < _minMax.Length; i++)
        {
            bool paint = false;
            if (_minMax[i] == min)
                paint = true;

            _minMaxCells[i].Fill(_minMax[i], paint);
        }

        float max = _maxMin.Max(x => x);
        for (int i = 0; i < _maxMin.Length; i++)
        {
            bool paint = false;
            if (_maxMin[i] == max)
                paint = true;

            _maxMinCells[i].Fill(_maxMin[i], paint);
        }
    }

    private void FindMaxMin()
    {
        _maxMin = new float[4];
        for (int i = 0; i < 4; i++)
        {
            float min = float.MaxValue;
            for (int j = 0; j < 4; j++)
            {
                if (_matrix[i, j] < min)
                {
                    min = _matrix[i, j];
                }
            }
            _maxMin[i] = min;
        }
    }

    private void FindMinMax()
    {
        _minMax = new float[4];
        for (int i = 0; i < 4; i++)
        {
            float max = float.MinValue;
            for (int j = 0; j < 4; j++)
            {
                if (_matrix[j, i] > max)
                {
                    max = _matrix[j, i];
                }
            }
            _minMax[i] = max;
        }
    }

    private void OnDestroy()
    {
        SpellsData.Instance.OnDataChange -= Fill;
    }
}
