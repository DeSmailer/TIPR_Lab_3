using System;
using UnityEngine;

public class SpellsData : MonoBehaviour
{
    private static SpellsData _instance;
    public static SpellsData Instance { private set { _instance = value; } get { return _instance; } }

    private float _myDamage = 0;
    private float _myProtection = 0;
    private float _myHeal = 0;

    private float _enemyDamage = 0;
    private float _enemyProtection = 0;
    private float _enemyHeal = 0;

    public float MyDamage { get { return _myDamage; } set { _myDamage = value; } }
    public float MyProtection { get { return _myProtection; } set { _myProtection = value; } }
    public float MyHeal { get { return _myHeal; } set { _myHeal = value; } }

    public float EnemyDamage { get { return _enemyDamage; } set { _enemyDamage = value; } }
    public float EnemyProtection { get { return _enemyProtection; } set { _enemyProtection = value; } }
    public float EnemyHeal { get { return _enemyHeal; } set { _enemyHeal = value; } }


    public Action OnDataChange;

    public void Initialize()
    {
        if (Instance == null)
        { // Ёкземпл€р менеджера был найден
            Instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (Instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
    }

    public void SetData(float myDamage, float myProtection, float myHeal,
        float enemyDamage, float enemyProtection, float enemyHeal)
    {
        MyDamage = myDamage;
        MyProtection = myProtection;
        MyHeal = myHeal;

        EnemyDamage = enemyDamage;
        EnemyProtection = enemyProtection;
        EnemyHeal = enemyHeal;

        OnDataChange?.Invoke();
    }
}
