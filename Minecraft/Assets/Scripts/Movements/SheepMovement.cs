using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    private Vector3 initialPosition; // Position initiale du mouton
    private Vector3 targetPosition; // Position cible vers laquelle le mouton se déplacera
    private bool movingForward = true; // Indique si le mouton se déplace vers l'avant ou vers l'arrière

    private float distanceToTravel = 10f; // Distance que le mouton va parcourir avant de faire demi-tour
    private float moveSpeed = 2f; // Vitesse de déplacement du mouton

    void Start()
    {
        initialPosition = transform.position; // Enregistrer la position initiale du mouton
        targetPosition = GetRandomTargetPosition(); // Définir la position cible vers laquelle le mouton va se déplacer
    }

    void Update()
    {
        // Si le mouton est en train de se déplacer vers l'avant
        if (movingForward)
        {
            // Déplacer le mouton vers la position cible
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Si le mouton atteint la position cible, changer de direction
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingForward = false; // Changer de direction
                transform.LookAt(initialPosition); // Tourner la tête du mouton vers sa position initiale
            }
        }
        // Si le mouton est en train de faire demi-tour
        else
        {
            // Déplacer le mouton vers sa position initiale
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            // Si le mouton atteint sa position initiale, changer de direction
            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
            {
                movingForward = true; // Changer de direction
                targetPosition = GetRandomTargetPosition(); // Définir une nouvelle position cible vers laquelle le mouton va se déplacer
                transform.LookAt(targetPosition); // Tourner la tête du mouton vers sa nouvelle position cible
            }
        }
    }

    // Obtenir une position cible aléatoire dans un rayon de 2 mètres autour du point de départ
    private Vector3 GetRandomTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * distanceToTravel;
        randomDirection += initialPosition;
        randomDirection.y = transform.position.y;
        return randomDirection;
    }
}
