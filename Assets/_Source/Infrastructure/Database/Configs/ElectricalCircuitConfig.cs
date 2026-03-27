using Contracts.Configs;
using UnityEngine;

namespace Infrastructure.Database.Configs
{
    [CreateAssetMenu(fileName = "ElectricalCircuit", menuName = "Scriptable/Configs/ElectricalCircuit")]
    public class ElectricalCircuitConfig : ScriptableObject, IElectricalCircuitConfig
    {
        public float Power => _power;
        public float Resistance => _resistance;
        
        [SerializeField] private float _power;
        [SerializeField] private float _resistance;
    }
}