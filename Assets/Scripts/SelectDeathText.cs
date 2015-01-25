using UnityEngine;
using System.Collections;

public class SelectDeathText : MonoBehaviour
{
    void Start()
    {
        GenericWriteoutScript thingy = GetComponent<GenericWriteoutScript>();
        if (GameData.Instance.naturalCauseOfDeath)
            thingy.text = "Your journey ends here, after a valient effort to achieve honorable goals.";
        else if (GameData.Instance.allAnswers[1] == 3)
            thingy.text = "The king didn't really appreciate your reasoning.";
        thingy.enabled = true;
    }
}
