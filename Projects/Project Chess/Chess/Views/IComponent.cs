using System;
namespace Chess.Views;
public interface IComponent
{
    string ComponentName { get; }
    void Invoke();
}