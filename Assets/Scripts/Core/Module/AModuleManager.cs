namespace HoodedCrow.Core
{
    using UnityEngine;

    public abstract class AModuleManager: ScriptableObject
    {
        public abstract void Initialize(GameManager gameManager);
        public abstract void UnInitialize(GameManager gameManager);
    }
}
