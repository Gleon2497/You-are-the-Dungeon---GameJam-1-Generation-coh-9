using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> aros;
    private int currentIndex = 0;
    public float rotationSpeed = 90f;
    public AudioClip changeRingSound;

    // Diccionario para almacenar los colores originales de cada material de cada aro
    private Dictionary<GameObject, Color[]> originalColors = new Dictionary<GameObject, Color[]>();

    void Start()
    {
        // Guardar los colores originales de los materiales de cada aro
        foreach (GameObject aro in aros)
        {
            Renderer renderer = aro.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material[] materials = renderer.materials;
                Color[] colors = new Color[materials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    colors[i] = materials[i].color;
                }
                originalColors[aro] = colors;
            }
        }
        UpdateSelection();
    }

    void Update()
    {
        // seleccion de aros
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentIndex < aros.Count - 1)
            {
                currentIndex++;
                UpdateSelection();
                AudioManager.Instance.PlaySFX(changeRingSound);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                UpdateSelection();
                AudioManager.Instance.PlaySFX(changeRingSound);
            }
        }

        // Rotación del aro seleccionado
        if (Input.GetKey(KeyCode.D))
        {
            RotateSelectedAro(-1); // sentido del reloj
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateSelectedAro(1); // sentido contrario al reloj
        }
    }

    // Actualiza el color del aro seleccionado y restablece los colores originales de los demás
    void UpdateSelection()
    {
        for (int i = 0; i < aros.Count; i++)
        {
            Renderer renderer = aros[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                Material[] materials = renderer.materials;
                for (int j = 0; j < materials.Length; j++)
                {
                    if (i == currentIndex)
                    {
                        // Color amarillo para el aro seleccionado
                        materials[j].color = Color.grey;
                    }
                    else
                    {
                        // Restaurar color original
                        materials[j].color = originalColors[aros[i]][j];
                    }
                }
            }
        }

        Debug.Log("Aro seleccionado: #" + (currentIndex + 1));
    }

    // Rota el aro actualmente seleccionado en el eje Y
    void RotateSelectedAro(int direction)
    {
        if (aros[currentIndex] != null)
        {
            aros[currentIndex].transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);
        }
    }


}


