using System.Collections.Generic;
using UnityEngine;

public class GameStateSubject : MonoBehaviour
{
    private List<IGameStateObserver> observers = new List<IGameStateObserver>();
    public void AddObserver(IGameStateObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IGameStateObserver observer) {  observers.Remove(observer);}
    public void StartGameAct()
    {
        foreach (var observer in observers) observer.StartState();
    }
    public void OverGameAct()
    {
        foreach (var observer in observers) observer.OverState();
    }
}
