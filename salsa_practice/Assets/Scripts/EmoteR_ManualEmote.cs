using CrazyMinnow.SALSA;
using UnityEngine;
using UnityEngine.UI;

public class EmoteR_ManualEmote : MonoBehaviour
{
    public Emoter emoter;
    public Dropdown dropdown;
    private bool emoteState = false;

    public void TriggerEmote()
    {
        string emoteName = dropdown.captionText.text;
        //Debug.Log(emoteName);
        if (!("none".Equals(emoteName)))
        {
            emoteState = !emoteState;
            emoter.ManualEmote(emoteName, ExpressionComponent.ExpressionHandler.RoundTrip, 2f);
        }
        
    }

    public void ToggleEmote()
    {
        string emoteName = dropdown.captionText.text;
        //Debug.Log(emoteName);
        if (!("none".Equals(emoteName)))
        {
            emoteState = !emoteState;
            emoter.ManualEmote(emoteName, ExpressionComponent.ExpressionHandler.OneWay, 0f, emoteState);
        }
    }
}
