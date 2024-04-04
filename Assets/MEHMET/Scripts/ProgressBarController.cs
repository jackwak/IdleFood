using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _progressBarImage;
    [SerializeField] private GameObject _progressBarPanel;

    [Header("Variables")]
    private bool _startProgressBar;
    private float _passingTime;
    private float _targetTime;

    private void Update()
    {
        if (_startProgressBar)
        {
            _progressBarPanel.transform.LookAt(Camera.main.transform);
            _passingTime += Time.deltaTime;
            _progressBarImage.fillAmount = _passingTime / _targetTime;
            if (_passingTime > _targetTime)
            {
                //add audio (start progress bara sesi eklersin ref olarak)

                _startProgressBar = false;

                _progressBarPanel.gameObject.SetActive(false);
            }
        }
    }

    public void StartProgressBar(float targetTime)
    {
        _targetTime = targetTime;
        _progressBarPanel.gameObject.SetActive(true);
        _passingTime = 0;   
        
        _startProgressBar = true;
    }
}
