using UnityEngine;

public class ControlMovement : MonoBehaviour
{
    [SerializeField] private CharacterType character;

    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;
    private EnemyMovement enemyMovement;
    private enum CharacterType
    {
        Player,
        Enemy
    }

    private void Awake()
    {
        if (character.Equals(CharacterType.Player))
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerShoot = FindObjectOfType<PlayerShoot>();
        }
        else enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    public void StopMovement() => ChangeState(false);

    public void StartMovement() => ChangeState(true);

    public void PlayerDeath()
    {
        playerMovement.enabled = false;
        playerShoot.enabled = false;
    }

    private void ChangeState(bool state)
    {
        if (character.Equals(CharacterType.Player)) playerMovement.enabled = state;
        else enemyMovement.enabled = state;
    }
}