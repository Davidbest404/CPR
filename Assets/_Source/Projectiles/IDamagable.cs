using System;
using UnityEngine;

public interface IDamagable
{
    public abstract int Health { get; }
    public abstract void Damage(int Damage);
}
