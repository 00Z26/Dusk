using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{ 
  public string from;
  public string to;
  public void TeleportToScene()
  {
        GameObject.Find("Transition").GetComponent<Transport>().Transition(from, to);
    }

}
