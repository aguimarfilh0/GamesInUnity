using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour
{
    [Header("Rocket")]
    [SerializeField] private int speed;
    [SerializeField] private int speedMax;

    [Space(10)]
    [SerializeField] private int acceleration;
    [SerializeField] private int accelerationMax;

    [Space(10)]
    [SerializeField] private Rigidbody _rocketRig;
    [SerializeField] private Rigidbody _rocketNoseRig;

    private bool launch;

    private float fuel;

    [Header("Landing System")]
    [SerializeField] public float rotationSpeed;
    
    private bool landing;

    [Header("Attributes")]
    [SerializeField] private Slider fillFuelSlider;
    [SerializeField] private GameObject fillFuelUI;
    [SerializeField] private Image fuelBarUI;

    [Space(10)]
    [SerializeField] private ParticleSystem postCombustion;
    [SerializeField] private ParticleSystem glow;

    [Space(10)]
    [SerializeField] private GameObject _rocketJetSFX;

    [Space(10)]
    [SerializeField] private GameObject rocketParachute;
    
    private void Start()
    {
        _rocketNoseRig.isKinematic = true;
        _rocketNoseRig.detectCollisions = false;
    }
    
    private void Update()
    {
        RocketLaunch();
        RocketLanding();
    }

    #region Launch
    private void RocketLaunch()
    {
        // Inicia o lançamento do foguete
        if (!launch && speedMax > 0)
        {
            launch = true;
        }

        if (launch)
        {
            fuel -= 0.1f;

            // Enquanto ouver combustível
            if (fuel > 0)
            {
                speed += acceleration;

                if (speed > accelerationMax)
                {
                    speed = accelerationMax;
                }

                fuelBarUI.fillAmount = fuel / 30;

                _rocketRig.AddForce(transform.up * speed * Time.deltaTime);
            }
            else
            {
                speed = 0;
                fillFuelSlider.value = 0;        
            }
        }

        // Se ouver combustível
        if (fuel > 0 )
        {
            _rocketJetSFX.SetActive(true);
            
            postCombustion.Play();
            glow.Play();

            _rocketRig.drag = 0;
        }
        else
        {
            launch = false;

            _rocketJetSFX.SetActive(false);

            postCombustion.Stop();
            glow.Stop();    

            _rocketRig.drag = 2;
        }

        // Ao chegar em uma certa altura o foguete para de decolar
        if (_rocketRig.velocity.y >= 25 && !landing)
        {
            IEnumerator ActiveParachute()
            {
                yield return new WaitForSeconds(0.5f);
                rocketParachute.SetActive(true);

                // Inicia a fase de pouso
                landing = true;
            }

            fillFuelUI.SetActive(false);
            
            fuel = 0;

            // Separar o compartimento 
            _rocketNoseRig.isKinematic = false;
            _rocketNoseRig.detectCollisions = true;
            _rocketNoseRig.drag = 4;

            // Ativar paraquedas
            StartCoroutine(ActiveParachute());
        }
    }
    #endregion

    #region Landing
        private void RocketLanding()
        {
            if (landing)
            {
                float horizontalInput = Input.GetAxis("Horizontal");

                // Crie um vetor de direção com base na entrada do jogador
                Vector3 inputDirection = new Vector3(horizontalInput, 0, 0).normalized;

                // Calcule o vetor de direção desejado com base na direção atual e na entrada do jogador
                Vector3 desiredDirection = Vector3.RotateTowards(transform.forward, inputDirection, rotationSpeed * Time.deltaTime, 0.0f);

                // Aplique a rotação suavemente
                Quaternion newRotation = Quaternion.LookRotation(desiredDirection);
                _rocketRig.MoveRotation(newRotation);
            }
        }
    #endregion

    #region Collision
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("LandingArea") && landing)
            {
                landing = false;
                rocketParachute.SetActive(false);
            }
        }
    #endregion

    #region UI
    public void SubmitFillFuelSlider()
    {
        speedMax = Mathf.RoundToInt(fillFuelSlider.value * 100);

        fuel = speedMax;
        fuelBarUI.fillAmount = fillFuelSlider.value;
    }
    #endregion
}
