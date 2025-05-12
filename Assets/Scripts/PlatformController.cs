using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> aros;
    private int currentIndex = 0;
    public float rotationSpeed = 90f;

    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        // seleccion de aros
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentIndex < aros.Count - 1)
            {
                currentIndex++;
                UpdateSelection();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                UpdateSelection();
            }
        }

        // Rotación del aro seleccionado
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateSelectedAro(-1); // sentido del relij
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateSelectedAro(1); // sentido contrario al reloj
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < aros.Count; i++)
        {
            bool isSelected = (i == currentIndex);

            // Ejemplo visual: color del aro seleccionado
            Renderer renderer = aros[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = isSelected ? Color.gray : Color.white;
            }
        }

        Debug.Log("Aro seleccionado: #" + (currentIndex + 1));
    }

    void RotateSelectedAro(int direction)
    {
        if (aros[currentIndex] != null)
        {
            aros[currentIndex].transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);
        }
    }


}


