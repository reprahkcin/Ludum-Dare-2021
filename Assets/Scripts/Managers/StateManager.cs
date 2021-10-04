using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoSingleton<StateManager>
{
  private int _income = 0;
  private int _points = 0;
  private int _attendees = 0;

  public void AddIncome(int amount) {
    _income += amount;
  }

  public void AddPoints(int amount) {
    _points += amount;
  }

  public void AddAttendee(int amount) {
    _attendees += amount;
  }

  public int GetIncome() {
    return this._income;
  }

  public int GetPoints() {
    return _points;
  }

  public int GetAttendees() {
    return _attendees;
  }
}
