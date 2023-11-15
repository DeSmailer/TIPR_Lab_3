using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseController : MonoBehaviour
{
    [SerializeField] private StepManager _stepManager;

    [SerializeField] private GameObject _winLoseWindow;

    [SerializeField] private GameObject _winGameObject;
    [SerializeField] private GameObject _loseGameObject;
    [SerializeField] private GameObject _drawGameObject;

    [SerializeField] private HP _myHP;
    [SerializeField] private HP _enemyHP;

    public void Initialize()
    {
        _winLoseWindow.SetActive(false);
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
        _winLoseWindow.SetActive(true);

        _winGameObject.SetActive(true);
        _loseGameObject.SetActive(false);
        _drawGameObject.SetActive(false);
    }

    private void Lose()
    {
        _winLoseWindow.SetActive(true);

        _winGameObject.SetActive(false);
        _loseGameObject.SetActive(true);
        _drawGameObject.SetActive(false);
    }

    private void Draw()
    {
        _winLoseWindow.SetActive(true);

        _winGameObject.SetActive(false);
        _loseGameObject.SetActive(false);
        _drawGameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        _stepManager.OnStepEnd -= Check;
    }
}
