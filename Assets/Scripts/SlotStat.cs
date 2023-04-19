using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SlotStat : MonoBehaviour
{
    // Inspector
    [Header("Slot Stat")]
    [SerializeField] private string nombre;
    [SerializeField] private Sprite icono;
    [SerializeField] private Color color;

    //Private
    private Image _icono;
    private TMP_Text _texto;
    private Image _barra;

    private void ObtenerComponentes()
    {
        _icono = transform.GetChild(1).GetComponent<Image>();
        _texto = transform.GetChild(2).GetComponent<TMP_Text>();
        _barra = transform.GetChild(3).GetChild(0).GetComponent<Image>();
    }

    private void AplicarCambios()
    {
        _icono.sprite = icono;
        _texto.text = nombre;
        _barra.color = color;
        gameObject.name = nombre;
    }

    private void Awake()
    {
        ObtenerComponentes();
        AplicarCambios();
    }

    private void OnValidate()
    {
        ObtenerComponentes();
        AplicarCambios();
    }

    public string Texto
    {
        set => _texto.text = nombre + ": " + value;
    }

    public float BarraRelleno
    {
        set => _barra.fillAmount = value;
    }
}
