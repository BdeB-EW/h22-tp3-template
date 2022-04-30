using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCamera : MonoBehaviour
{
    [SerializeField] private float vitesseHorizontale;
    [SerializeField] private float vitesseVerticale;
    [SerializeField] private float vitesseDeroulement;
    [SerializeField] private float facteurAcceleration;
     
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 40, -290);
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacement de la caméra
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * vitesseHorizontale;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * vitesseVerticale;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontal *= facteurAcceleration;
            vertical *= facteurAcceleration;
        }
        float nouveauX = transform.position.x + horizontal;
        float nouveauZ = transform.position.z + vertical;
        nouveauX = Mathf.Clamp(nouveauX, -200.0f, 200.0f);
        nouveauZ = Mathf.Clamp(nouveauZ, -290.0f, 85.0f);
        if (Input.GetKey(KeyCode.PageUp))
        {
            transform.position += Vector3.up * Time.deltaTime * vitesseDeroulement;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            transform.position += Vector3.down * Time.deltaTime * vitesseDeroulement;
        }
        float nouveauY = Mathf.Clamp(transform.position.y, 10.0f, 90.0f);
        transform.position = new Vector3(nouveauX, nouveauY, nouveauZ);


        // On regarde en direction de 100 plus loin sur l'axe des z avec un y de 0.
        Vector3 objectif = new Vector3(transform.position.x, 0, transform.position.z + 100);
        Vector3 direction = objectif - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

    }
}
