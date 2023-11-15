using UnityEngine;

public class WinLoseController : MonoBehaviour
{
    [SerializeField] private StepManager _stepManager;

    [SerializeField] private GameObject _winGameObject;
    [SerializeField] private GameObject _loseGameObject;

    [SerializeField] private HP _myHP;
    [SerializeField] private HP _enemyHP;

    public void Initialize()
    {
        _stepManager.OnStepEnd += Check;
    }

    private void Check()
    {
        if (_myHP.CurrentHP > 0 && _enemyHP.CurrentHP <= 0)
        {
            Win();
        }
        else if (_myHP.CurrentHP <= 0 && _enemyHP.CurrentHP > 0)
        {
            Lose();
        }
        else if (_myHP.CurrentHP <= 0 && _enemyHP.CurrentHP <= 0)
        {
            Draw();
        }
    }

    private void Win()
    {

    }

    private void Lose()
    {

    }

    private void Draw()
    {

    }

    private void OnDestroy()
    {
        _stepManager.OnStepEnd -= Check;
    }
}
