using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoSingleton<StateManager>
{
  private int _income = 0;
  private int _points = 0;

  public void AddIncome(int amount) {
    _income += amount;
  }

  public void AddPoints(int amount) {
    _points += amount;
  }

  static public int GetIncome() {
    return _income;
  }

  static public int GetPoints() {
    return _points;
  }
}
