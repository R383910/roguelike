using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Les données de l'ennemi
    public EnemyData enemyData;

    private void Start()
    {
        // Initialiser l'ennemi lors du démarrage
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        // Vérifier si les données de l'ennemi sont assignées
        if (enemyData == null)
        {
            Debug.LogError("EnemyData n'est pas assigné à EnemyController !");
            return;
        }

        // Vérifier si le modèle de l'ennemi est assigné
        if (enemyData.enemyModel == null)
        {
            Debug.LogError("enemyModel n'est pas assigné dans EnemyData !");
            return;
        }

        // Vérifier si le composant Animator est assigné
        if (enemyData.anim == null)
        {
            Debug.LogError("AnimatorController n'est pas assigné dans EnemyData !");
            return;
        }

        // Assurez-vous que le modèle de l'ennemi a le même parent que l'objet EnemyController
        enemyData.enemyModel.transform.parent = transform;

        // Optionnellement, définir d'autres propriétés telles que la santé, la vitesse, les dégâts, etc.
        // enemyData.enemyModel.GetComponent<YourEnemyScript>().SetHealth(enemyData.health);
        // enemyData.enemyModel.GetComponent<YourEnemyScript>().SetSpeed(enemyData.speed);
        // enemyData.enemyModel.GetComponent<YourEnemyScript>().SetDamage(enemyData.damage);
    }

    // Méthode pour jouer une animation spécifiée par son nom
    public void PlayAnimation(string nomAnimation)
    {
        // Vérifier si le composant Animator est initialisé
        if (enemyData.anim == null)
        {
            Debug.LogError("AnimatorController n'est pas initialisé !");
            return;
        }

        // Jouer l'animation spécifiée en déclenchant l'état correspondant
        enemyData.anim.Play(nomAnimation, 0, 0f);
    }
}