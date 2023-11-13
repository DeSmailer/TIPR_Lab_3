using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{
    [SerializeField] private Image _myCurrentSpellImage;
    [SerializeField] private Image _enemyCurrentSpellImage;

    [SerializeField] private SelectedSpells _selectedSpells;
    [SerializeField] private EnemySpells _enemySpells;

    [SerializeField] private Action OnEnded1;
    [SerializeField] private Action OnEnded2;

    [SerializeField] private float _delay;

    private bool readyForNextStep = false;

    private bool ended1 = false;
    private bool ended2 = false;

    public Action OnStepEnd;

    private void Awake()
    {
        OnEnded1 += OnEnded1Handler;
        OnEnded2 += OnEnded2Handler;
    }

    private void Update()
    {
        if (readyForNextStep == false)
        {
            if (ended1 == true && ended2 == true)
            {
                StartCoroutine(DelayBeetwenNexStep(_delay));
            }
        }
    }

    private IEnumerator DelayBeetwenNexStep(float delay)
    {
        yield return new WaitForSeconds(delay);

        readyForNextStep = true;
        OnStepEnd?.Invoke();
    }

    public void NextStep()
    {
        if (!readyForNextStep)
            return;

        Spell selectedSpell = _selectedSpells.SelectedSpell;
        Spell enemySpell = _enemySpells.SelectedSpell;
        if (selectedSpell != null && enemySpell != null)
        {
            _myCurrentSpellImage.sprite = selectedSpell.Sprite;
            _enemyCurrentSpellImage.sprite = enemySpell.Sprite;

            selectedSpell.Activate(OnEnded1);
            enemySpell.Activate(OnEnded2);
        }

    }

    private void OnEnded1Handler()
    {
        Debug.Log("OnEnded 1 Handler");
        ended1 = true;
    }

    private void OnEnded2Handler()
    {
        Debug.Log("OnEnded 2 Handler");
        ended2 = true;
    }

    private void OnDestroy()
    {
        OnEnded1 -= OnEnded1Handler;
        OnEnded2 -= OnEnded2Handler;
    }
}
