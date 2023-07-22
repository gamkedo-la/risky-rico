using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;d
public class LevelEscape : MonoBehaviour, IInteractable
{
    [Header("INTERACTIONS")]
    [SerializeField] private string _interactionPrompt;
    [SerializeField] private IntVariable _playerMoney;

    public string Prompt {get; set; }
    public bool InteractionEnabled {get; set; }

    void Start()
    {
        Prompt = _interactionPrompt;
        InteractionEnabled = true;
    }

    public void ReceiveInteraction(GameObject interactor)
    {
       ServiceLocator.Instance.Get<SaveDataManager>().SetOnHandMoney(_playerMoney.Value);
       ServiceLocator.Instance.Get<LevelManager>().EscapeLevel();
    }
}
