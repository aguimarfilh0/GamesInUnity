using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketUI : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private RocketController _rocketController;

    [Space(10)]
    [SerializeField] private Slider fillFuelSlider;
    [SerializeField] private Image fuelBarUI;
    
    #region UI
        public void SubmitFillFuelSlider()
        {
            // Adiciona uma velocidade máxima para o foguete
            _rocketController.SpeedMax = Mathf.RoundToInt(fillFuelSlider.value * 100);

            // Adiciona gasolina para o foguete decolar
            _rocketController.Fuel = _rocketController.SpeedMax;
            
            fuelBarUI.fillAmount = fillFuelSlider.value;
        }
    #endregion
}
