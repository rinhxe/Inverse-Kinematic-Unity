using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl: MonoBehaviour {
    public static UICtrl instance;

    [SerializeField] private Button ActionButton;
    [SerializeField] private TextMeshProUGUI ActionButtonTextUGUI;

    [SerializeField] private Joytick joytick;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    private void Start() {
        ActionButton.onClick.AddListener(OnclickActionButton);
    }

    private void OnclickActionButton() {
       // BeginSquat();
       //Script for begin action
    }

 

    public void SetJoystickStatus(bool set) {
        joytick.gameObject.SetActive(set);
    }

    public void ShowActionButton(ActionType type) {
        ActionButtonTextUGUI.text = type.ToString();

        ActionButton.gameObject.SetActive(true);
        
    }

    public void HideActionButton() {
        ActionButton.gameObject.SetActive(false);
    }

}
