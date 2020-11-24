using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField]private int currentLevel;

    public void LoadNext()
    {
         Scene.Load(currentLevel);
         currentLevel++;
    }
}
