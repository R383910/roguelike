using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "My Game/Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public string description;
    public GameObject playerModel;
    public AnimatorController anim;
    public int health;
    public float speed;
    public int damage;
}