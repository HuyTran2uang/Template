using Simple.Strategy;
using UnityEngine;

namespace Simple.DesignPattern.Strategy
{
    public class Context
    {
        private IAlgorithm _currentAlgorithm;

        public void Start()
        {
            //_currentAlgorithm = new .....()
            _currentAlgorithm?.Execute();
        }
    }
}
