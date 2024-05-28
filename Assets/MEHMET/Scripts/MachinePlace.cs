using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MachinePlace : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _machinePlaceUIPanel;
    [SerializeField] private MachinePositionManager _machinePositionManager;
    [SerializeField] private Machine _machine;
    [SerializeField] private TextMeshProUGUI _buyMachinePriceText;
    [SerializeField] private Transform _hand;

    [Header("Variables")]
    [SerializeField] private int _buyMachinePrice;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt(_machine.name + "Bought"));
        if (!PlayerPrefs.HasKey(_machine.name + "Bought"))
        {
            PlayerPrefs.SetInt(_machine.name + "Bought", 0);
        }

        if (PlayerPrefs.GetInt(_machine.name + "Bought") == 1)
        {
            Destroy(_hand.gameObject);
            Destroy(gameObject);
        }
        Debug.Log("Satýn Alýndý mý" + PlayerPrefs.GetInt(_machine.name + "Bought"));

        _buyMachinePriceText.text = _buyMachinePrice.ToString();
        _hand.DOScale(_hand.localScale + Vector3.one, 1f).From(_hand.transform.localScale).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    [ContextMenu("ResetDatas")]
    public void ResetDatas()
    {
        
        PlayerPrefs.SetInt(_machine.name + "Bought", 0);
        Debug.Log(" machine place :" + PlayerPrefs.GetInt(_machine.name + "Bought"));
    }

    private void OnEnable()
    {
        InputManager.OnStartTouch += OpenCloseMachinePlacePanel;
    }

    private void OnDisable()
    {
        InputManager.OnStartTouch -= OpenCloseMachinePlacePanel;
    }


    private void OpenCloseMachinePlacePanel(Vector2 vector2)
    {
        // Dokunulan noktayý 3D uzayda bir ýþýn haline getir
        Ray ray = Camera.main.ScreenPointToRay(vector2);
        RaycastHit hit;

        // Iþýn bir nesneye çarparsa
        if (Physics.Raycast(ray, out hit))
        {
            // Çarpýlan nesneyi kontrol et

            GameObject touchedObject = hit.transform.gameObject;
            // Burada dokunulan nesneyle ilgili yapýlacak iþlemleri gerçekleþtirin

            if (touchedObject.transform.name == "Machine Place" && _machinePlaceUIPanel.activeSelf == false) 
            {
                AudioManager.Instance.Play("UIClick");
                _machinePlaceUIPanel.SetActive(true);
                _machinePlaceUIPanel.transform.DOScale(Vector3.one, .5f).From(Vector3.zero).SetEase(Ease.OutBack);
                _hand.gameObject.SetActive(false);
            }
            else if (touchedObject.transform.name == "Machine Place" && _machinePlaceUIPanel.activeSelf == true)
            {
                _machinePlaceUIPanel.transform.DOScale(Vector3.zero, .5f).From(Vector3.one).SetEase(Ease.InBack).
                    OnComplete(()=> _machinePlaceUIPanel.SetActive(false));
                _hand.gameObject.SetActive(true);
            }
            else if (_machinePlaceUIPanel.activeSelf == true)
            {
                _machinePlaceUIPanel.transform.DOScale(Vector3.zero, .5f).From(Vector3.one).SetEase(Ease.InBack).
                    OnComplete(() => _machinePlaceUIPanel.SetActive(false));
                _hand.gameObject.SetActive(true);
            }
        }
        else
        {
            if (_machinePlaceUIPanel.activeSelf == true)
            {
                _machinePlaceUIPanel.transform.DOScale(Vector3.zero, .5f).From(Vector3.one).SetEase(Ease.InBack).
                    OnComplete(() => _machinePlaceUIPanel.SetActive(false));
                _hand.gameObject.SetActive(true);
            }
        }
    }

    public void AddMachine()
    {
        if (MoneyManager.Instance.playerMoney >= _buyMachinePrice)
        {
            //remove money
            MoneyManager.Instance.RemoveMoney(_buyMachinePrice);

            //Sound
            AudioManager.Instance.Play("Coin");

            GetComponent<MeshRenderer>().enabled = false;
            _machine.gameObject.SetActive(true);
            _machinePositionManager.AddMachine(_machine);
            _machine.transform.DOScale(_machine.transform.localScale, .4f).From(Vector3.zero).SetEase(Ease.OutBack).
                OnComplete(() =>
                {
                    Destroy(_hand.gameObject);
                    Destroy(gameObject);
                });

            PlayerPrefs.SetInt(_machine.name + "Bought", 1);
        }
        else
        {
            //Sound
            AudioManager.Instance.Play("Cancel");
        }
        
    }
}
