using UnityEngine;

public class Boot : MonoBehaviour
{
    [SerializeField] private SpellsData _spellsData;
    [SerializeField] private UI _UI;
    [SerializeField] private StepManager _stepManager;
    [SerializeField] private WinLoseController _winLoseController ;

    private void Awake()
    {
        _spellsData.Initialize();
        _UI.Initialize();
        _stepManager.Initialize();
        _winLoseController.Initialize();
    }
}
