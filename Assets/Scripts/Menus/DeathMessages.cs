using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathMessages : MonoBehaviour
{

    [SerializeField] private TMP_Text deathMessage;
    [SerializeField] private string[] messages = {"Ooof", "Get better", "You got cooked", "It's not that hard", "Adjust your settings ?!?!?", "A 1mo old could be better", "Is the pain increasing?", "God help you"};

    // Start is called before the first frame update
    void Start()
    {
        deathMessage.text = messages[Random.Range(0, messages.Length)];
    }
}
