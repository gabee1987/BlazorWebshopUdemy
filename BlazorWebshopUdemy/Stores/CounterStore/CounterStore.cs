using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebshopUdemy.Stores.CounterStore
{
    public class CounterState
    {
        public int Count { get; }

        public CounterState( int count )
        {
            Count = count;
        }
    }

    public class CounterStore
    {
        private CounterState m_state;

        public CounterStore()
        {
            m_state = new CounterState( 0 );
        }

        public CounterState GetState()
        {
            return m_state;
        }

        public void IncrementCount()
        {
            var count = this.m_state.Count;
            count++;
            this.m_state = new CounterState( count );
            BroadcastStateChanged();
        }

        public void DecrementCount()
        {
            var count = this.m_state.Count;
            count--;
            this.m_state = new CounterState( count );
            BroadcastStateChanged();
        }

        #region Observer Pattern
        private Action m_listeners;

        public void AddStateChangedListeners( Action listener )
        {
            m_listeners += listener;
        }

        public void RemoveStateListeners( Action listener )
        {
            m_listeners -= listener;
        }

        public void BroadcastStateChanged()
        {
            m_listeners.Invoke();
        }
        #endregion
    }
}
