using CrazyMinnow.SALSA;
using UnityEngine;

public class EmoteR_ManualEmote : MonoBehaviour
{
    public Emoter emoter;
    private bool emoteState = false;

    public void TriggerEmote(string emoteName)
    {
        emoter.ManualEmote(emoteName, ExpressionComponent.ExpressionHandler.RoundTrip, 5f);
    }

    public void ToggleEmote(string emoteName)
    {
        emoteState = !emoteState;
        emoter.ManualEmote(emoteName, ExpressionComponent.ExpressionHandler.OneWay, 0f, emoteState);
    }
}
