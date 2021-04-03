using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReaction : MonoBehaviour
{
    [SerializeField][TextArea]
    private List<string> LookingPhrases;
    private int _lookingPhraseIndex = 0;
    [SerializeField]
    [TextArea]
    private List<string> InteractionPhrases;
    private int _interactionPhraseIndex = 0;
    [SerializeField][TextArea]
    private List<string> NoInteractionPhrases;
    private int _noInteractionPhraseIndex = 0;
    
    public string LookingPhrase 
    { 
        get {return GetPhrase(LookingPhrases, ref _lookingPhraseIndex);} 
    }
    public string InteractionPhrase
    {
        get { return GetPhrase(LookingPhrases, ref _interactionPhraseIndex); }
    }
    public string NonInteractionPhrase
    {
        get => GetPhrase(NoInteractionPhrases, ref _noInteractionPhraseIndex);
    }

    public IEnumerator ShowText(string text)
    {
        int i = 0;
        DialogPanel.Instance.Active(true);
        do
        {
            DialogPanel.Instance.Text.text += text[i++];

            yield return new WaitForSeconds(0.1f);
        } while (i < text.Length);

        do
        {
            if (Input.GetMouseButtonDown(0))
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        } while (true);
        DialogPanel.Instance.Active(false);
    }
    public void Reaction(string text)
    {
        StartCoroutine(ShowText(text));
    }
    private string GetPhrase(List<string> phrases, ref int index)
    {
        if (index >= phrases.Count)
        {
            index = 0;
        }
        return phrases[index++];
    }
}
