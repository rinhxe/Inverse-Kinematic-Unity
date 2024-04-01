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
        BeginSquat();

    }

    #region ScriptZone    
    private void BeginSquat() {

        CamCtrl.instance.SwitchToCamera(2);
   
        InputCtrl.instance.HideJoytick();
        ActionButton.gameObject.SetActive(false);
      
        PlayerController playerController = PlayerController.instance;
        playerController.SetRigBuilder(true);
        playerController.SetRigStatus(true);
        playerController.ChangePlayerFaceCamera();

    }
    public void EndSquat() {

        CamCtrl.instance.SwitchToCamera(1);
    
        InputCtrl.instance.ShowJoytick();
        ActionButton.gameObject.SetActive(false);

        PlayerController playerController = PlayerController.instance;
        playerController.SetRigBuilder(false);
        playerController.SetRigStatus(false);


    }
    #endregion

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
