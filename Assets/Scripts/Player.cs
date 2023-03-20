using System.Collections;
using UnityEditor.UI;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movimiento")]
    [SerializeField] float velocidad = 2f;

    Vector3 axis;

    [Header("Componentes")]
    Transform sprite;
    Animator animator;

    // rotaciones
    int direccionAnim = -1;
    Quaternion rotacionDerecha;
    Quaternion rotacionIzquierda;

    Usable usableActivo;

    private void Awake()
    {
        sprite = transform.GetChild(0);
        animator = sprite.GetComponent<Animator>();

        rotacionDerecha = Quaternion.Euler(new Vector3(0, 180, 0));
        rotacionIzquierda = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void Start()
    {
        InicializarStats();
        InicializarCorrutinas();
    }

    // Update is called once per frame
    void Update()
    {
        axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (usableActivo)
                usableActivo.Usar(this);
        }
    }

    private void FixedUpdate()
    {
        if (axis != Vector3.zero)
        {
            var deltaTime = Time.fixedDeltaTime;
            transform.position += axis * deltaTime * velocidad;
            animator.SetInteger("idle", 2);

            if (axis.x != 0)
            {

                direccionAnim = 0;

                if (axis.x > 0)
                {
                    transform.localRotation = rotacionDerecha;
                }
                else
                {
                    transform.localRotation = rotacionIzquierda;
                }
            }
            else
            {
                direccionAnim = (int)axis.y;
            }
            animator.SetInteger("caminar", direccionAnim);
        }
        else
        {
            animator.SetInteger("caminar", 2);
            animator.SetInteger("idle", direccionAnim);
        }
    }

    #region Triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Usable":
                Usable usable = collision.GetComponent<Usable>();
                usable.Activado = true;
                usableActivo = usable;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Usable":
                Usable usable = collision.GetComponent<Usable>();
                usable.Activado = false;
                usableActivo = null;
                break;
        }
    }

    #endregion

    #region Stats

    [Header("Stats")]

    [SerializeField] int _sleepMax;
    [SerializeField] float tiempoConsumoSleep;

    [SerializeField] int _sedMax;
    [SerializeField] float tiempoConsumoSed;

    [SerializeField] int _calorMax;
    [SerializeField] float tiempoConsumoCalor;

    [SerializeField] int _hambreMax;
    [SerializeField] float tiempoConsumoHambre;

    [SerializeField] int _limpiezaMax;
    [SerializeField] float tiempoConsumoLimpieza;

    private int _sleep;
    private int _sed;
    private int _calor;
    private int _hambre;
    private int _limpieza;
    private int _monedas = 0;

    private void InicializarStats()
    {
        Sleep = _sleepMax;
        Sed = _sedMax;
        Calor = _calorMax;
        Hambre = _hambreMax;
        Limpieza = _limpiezaMax;
        _monedas = 0;
    }

    private void InicializarCorrutinas()
    {
        StartCoroutine(CrConsumirSleep());
        StartCoroutine(CrConsumirSed());
        StartCoroutine(CrConsumirCalor());
        StartCoroutine(CrConsumirHambre());
        StartCoroutine(CrConsumirLimpieza());
    }

    private IEnumerator CrConsumirSleep()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(tiempoConsumoSleep);
            Sleep--;
        }
    }
    private IEnumerator CrConsumirSed()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(tiempoConsumoSed);
            Sed--;
        }
    }
    private IEnumerator CrConsumirCalor()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(tiempoConsumoCalor);
            Calor--;
        }
    }
    private IEnumerator CrConsumirHambre()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(tiempoConsumoHambre);
            Hambre--;
        }
    }
    private IEnumerator CrConsumirLimpieza()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(tiempoConsumoLimpieza);
            Limpieza--;
        }
    }

    private int limitValues(int currentValue, int minValue, int maxValue)
    {
        if (currentValue > maxValue)
        {
            return maxValue;
        }
        else if (currentValue <= minValue)
        {
            return minValue;
        }
        else
        {
            return currentValue;
        }
    }

    public int Sleep
    {
        get => _sleep;
        set
        {
            _sleep = limitValues(value, 0, _sleepMax);
            HUD.Sleep.Texto = _sleep + "/" + _sleepMax;
            HUD.Sleep.BarraRelleno = (float)_sleep/ _sleepMax;
        }
    }
    public int Sed
    {
        get => _sed;
        set
        {
            _sed = limitValues(value, 0, _sedMax);
            HUD.Sed.Texto = _sed + "/" + _sedMax;
            HUD.Sed.BarraRelleno = (float)_sed/ _sedMax;
        }
    }
    public int Calor
    {
        get => _sed;
        set
        {
            _calor = limitValues(value, 0, _calorMax);
            HUD.Calor.Texto = _calor + "/" + _calorMax;
            HUD.Calor.BarraRelleno = (float)_calor/ _calorMax;
        }
    }
    public int Hambre
    {
        get => _hambre;
        set
        {
            _hambre = limitValues(value, 0, _hambreMax);
            HUD.Hambre.Texto = _hambre + "/" + _hambreMax;
            HUD.Hambre.BarraRelleno = (float)_hambre/ _hambreMax;
        }
    }
    public int Limpieza
    {
        get => _limpieza;
        set
        {
            _limpieza = limitValues(value, 0, _limpiezaMax);
            HUD.Limpieza.Texto = _limpieza + "/" + _limpiezaMax;
            HUD.Limpieza.BarraRelleno = (float)_limpieza/ _limpiezaMax;
        }
    }

    public int Monedas
    {
        get => _monedas;
        set
        {
            _monedas = value;
            HUD.Monedas = value;
        }
    }

    #endregion
}

public enum Estados
{
    Idle,
    Caminando,
    atacando
}
