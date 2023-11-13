using System;

public interface ISpell
{
    public void Activate(Action OnEndCallback = null);
}
