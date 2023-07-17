using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("DIALOG")]
    [SerializeField, HideCustomDrawer] private DialogSequence _activeDialogueSequence;
    [SerializeField] private DialogSequence _npcDialogueSequence;
    [SerializeField] private List<DialogSequence> _availableDialog;
    [SerializeField] private DialogFlagDictionary _flaggedDialog;
    public bool useFlags = false;
    public bool randomDialog = false;
    public bool randomLine = false;

    [Header("EVENTS")]
    [SerializeField] private GameEvent _onDialogStart;
    [SerializeField] private GameEvent _onDialogEnd;

    [Header("INTERACTIONS")]
    [SerializeField] private string _interactionPrompt;

    public string Prompt { get; set; }
    public bool InteractionEnabled { get; set; }

    void Start()
    {
        Prompt = _interactionPrompt;
        InteractionEnabled = true;
    }

    public string GetFlaggedSequenceKey()
    {
        string flaggedSequenceKey = null;
        foreach (string flag in _flaggedDialog.Keys)
        {
            bool flagStatus = ServiceLocator.Instance.Get<SaveDataManager>().GetFlag(flag);
            if (flagStatus)
            {
                flaggedSequenceKey = flag;
            }
        }

        return flaggedSequenceKey;
    }

    public void SetCurrentDialogSequence(DialogSequence sequence)
    {
        _npcDialogueSequence = sequence;
    }

    public DialogSequence GetRandomDialogSequence()
    {
        return _availableDialog[Random.Range(0, _availableDialog.Count)];
    }

    public List<DialogLine> GetRandomDialogLine(DialogSequence dialog)
    {
        List<DialogLine> randomLines = new List<DialogLine>();
        randomLines.Add(dialog.Lines[Random.Range(0, dialog.Lines.Count)]);
        return randomLines;
    }

    public void ReceiveInteraction(GameObject interactor)
    {
        if (_npcDialogueSequence != null && _activeDialogueSequence != null)
        {
            // default to using flagged dialog first (takes priority)
            string flagKey = GetFlaggedSequenceKey();
            Debug.Log(flagKey);
            DialogSequence flaggedSequence = flagKey != null ? _flaggedDialog[flagKey] : null;
            DialogSequence selectedDialogSequence = useFlags && flaggedSequence != null ? flaggedSequence : _npcDialogueSequence;

            // if we do not have a flagged sequence to display and we allow random sequences, pick one
            selectedDialogSequence = randomDialog && flaggedSequence == null ? GetRandomDialogSequence() : selectedDialogSequence;

            // if we want a random line of a sequence, set our selected sequences lines to match the retrieved line
            List<DialogLine> selectedDialogLines = randomLine ? GetRandomDialogLine(selectedDialogSequence) : selectedDialogSequence.Lines;
            _activeDialogueSequence.SetLines(selectedDialogLines);

            // only set our end event if we have one to use
            _activeDialogueSequence.SetEndEvent(_onDialogEnd ? _onDialogEnd : selectedDialogSequence.OnDialogEnd);
            _onDialogStart?.Raise();

            // if we used flagged dialog, toggle off the flag for it so that we don't repeat it
            if (flagKey != null)
            {
                ServiceLocator.Instance.Get<SaveDataManager>().SetFlag(flagKey, false);
            }

            // disable further interaction until the dialog is completed
            InteractionEnabled = false;
        }
    }
}
