using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Movimiento hacia adelante constante
        transform.Translate(Vector3.forward * Time.deltaTime * 20);

        // Girar a la izquierda (A) o a la derecha (D) mientras la tecla esté siendo mantenida
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -5); // Ajusta la velocidad de rotación con "50"
            // transform.Rotate(Vector3.up, -5 * Time.deltaTime * 50); // Ajusta la velocidad de rotación con "50"
        }
        if (Input.GetKey(KeyCode.D))
        {
            // transform.Rotate(Vector3.up, 5 * Time.deltaTime * 50); // Ajusta la velocidad de rotación con "50"
            transform.Rotate(Vector3.up, 5); // Ajusta la velocidad de rotación con "50"
        }
    }

    // Detectar colisión con DeathZone
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }

    // Reiniciar la escena en caso de muerte
    void PlayerDeath()
    {
        SceneManager.LoadScene("Prototype 1");
    }
}
