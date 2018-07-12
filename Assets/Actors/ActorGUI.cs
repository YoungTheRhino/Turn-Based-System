using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorGUI : MonoBehaviour {

    public Text healthText;

    public void UpdateHealth(int h)
    {
        if(healthText == null)
        {
            return;
        }
        healthText.text = h.ToString();
    }
}
