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

    //[SerializeField] private Action OnEnded1;
    //[SerializeField] private Action OnEnded2;

    [SerializeField] private float _delayBeforeNextStep;

    [SerializeField] private bool readyForNextStep = true;

    [SerializeField] private bool ended1 = false;
    [SerializeField] private bool ended2 = false;

    public Action OnStepEnd;

    public void Initialize()
    {
        readyForNextStep = true;
    }

    private void Update()
    {
        if (readyForNextStep == false)
        {
            if (ended1 == true && ended2 == true)
            {
                StartCoroutine(DelayBeforeNextStep(_delayBeforeNextStep));
            }
        }
    }

    private IEnumerator DelayBeforeNextStep(float delay)
    {
        yield return new WaitForSeconds(delay);

        StepEnd();
    }

    private void StepEnd()
    {
        readyForNextStep = true;
        _selectedSpells.ResetSpells();
        _enemySpells.ResetSpells();
        ended1 = false;
        ended2 = false;
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

            readyForNextStep = false;
            ended1 = false;
            ended2 = false;

            if (selectedSpell.SpellType == SpellType.Copying || enemySpell.SpellType == SpellType.Copying)
            {
                if (selectedSpell.SpellType == SpellType.Copying && enemySpell.SpellType != SpellType.Copying)
                {
                    ((CopyingSpell)selectedSpell).Activate(enemySpell.SpellType, OnEnded1Handler);
                    enemySpell.Activate(OnEnded2Handler);
                }
                else if (selectedSpell.SpellType != SpellType.Copying && enemySpell.SpellType == SpellType.Copying)
                {
                    ((CopyingSpell)enemySpell).Activate(selectedSpell.SpellType, OnEnded2Handler);
                    selectedSpell.Activate(OnEnded1Handler);
                }
                else
                {
                    OnEnded1Handler();
                    OnEnded2Handler();
                }
            }
            else
            {
                selectedSpell.Activate(OnEnded1Handler);
                enemySpell.Activate(OnEnded2Handler);
            }
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

    //private void OnDestroy()
    //{
    //    OnEnded1 -= OnEnded1Handler;
    //    OnEnded2 -= OnEnded2Handler;
    //}
}
