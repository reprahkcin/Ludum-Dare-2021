using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoSingleton<AlertManager>
{
  public string[] messages ={"Sample 1", "Sample 2", "Sample 3"};

  public string[] GetAlerts() {
    return messages;
  }
}
