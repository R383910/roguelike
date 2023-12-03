using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "My Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string description;
    public GameObject enemyModel;
    public AnimatorController anim;
    public int health;
    public float speed;
    public int damage;
}
