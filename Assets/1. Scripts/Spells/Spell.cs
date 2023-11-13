using UnityEngine;

public abstract class Spell : MonoBehaviour, ISpell
{
    public abstract void Activate();
}
