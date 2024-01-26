using System.Collections;
using System.Collections.Generic;
using JvLib.Events;
using JvLib.Pooling;
using JvLib.Pooling.Objects;
using JvLib.Services;
using UnityEngine;

namespace Project.Gameplay.Enemy
{
    public class AEnemyBehaviour<TConfig> : PooledObject, IPoolListener
        where TConfig : AEnemyConfig
    {
        protected float Duration;
        protected float Time;

        private enum EStates
        {
            Init,
            Roam,
            Hit,
            Exit
        }

        private EventStateMachine<EStates> _eventStateMachine;
        
        public void OnActivate(params object[] pContexts)
        {
            if (pContexts.Length <= 0 || pContexts[0] is not TConfig config) return;
            
            Duration = config.Duration;
            Initialize(config);
        }
        
        protected virtual void Initialize(TConfig pConfig) { }
        
        protected virtual void Update()
        {
            Time += UnityEngine.Time.deltaTime;
            if (Time >= Duration)
                Deactivate();
        }
    }
}