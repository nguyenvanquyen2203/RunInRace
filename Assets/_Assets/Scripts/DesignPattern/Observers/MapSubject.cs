using System.Collections.Generic;
using UnityEngine;

public class MapSubject : MonoBehaviour
{
    private List<IMapObserver> observers = new List<IMapObserver>();
    public void AddObserver(IMapObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IMapObserver observer)
    {
        observers.Remove(observer);
    }
    public void SetSpeed(float speed)
    {
        foreach (IMapObserver observer in observers) observer.SetSpeed(speed);
    }
    public void ClearObservers() => observers.Clear();
}
