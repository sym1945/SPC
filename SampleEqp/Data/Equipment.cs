using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleEqp
{
    public class Equipment
    {
        #region Private Members

        private List<GlassData> _GlassData = new List<GlassData>();
        private Eqst _Eqst = Eqst.Normal;
        private Prst _Prst = Prst.Idle;

        #endregion


        #region Pulblic Properties

        public Eqst Eqst
        {
            get => _Eqst;
            set
            {
                if (_Eqst == value)
                    return;

                _Eqst = value;
                OnEqstChanged();
            }
        }

        public Prst Prst
        {
            get => _Prst;
            set
            {
                if (_Prst == value)
                    return;

                _Prst = value;
                OnPrstChanged();
            }
        }


        public IReadOnlyList<GlassData> GlassDatas => _GlassData;
        #endregion


        #region Events

        public event Action<Equipment> EqstChanged;
        public event Action<Equipment> PrstChanged;
        public event Action<Equipment, GlassData> GlassDataAdded;
        public event Action<Equipment, GlassData> GlassDataRemoved;
        public event Action ProcessDone;

        protected void OnEqstChanged() => EqstChanged?.Invoke(this);
        protected void OnPrstChanged() => PrstChanged?.Invoke(this);
        protected void OnGlassDataAdded(GlassData addGlass) => GlassDataAdded?.Invoke(this, addGlass);
        protected void OnGlassDataRemoved(GlassData removeGlass) => GlassDataRemoved?.Invoke(this, removeGlass);

        #endregion


        #region Public Methods

        public GlassData GetGlassData(string glassId = null)
        {
            if (glassId == null)
                return _GlassData.FirstOrDefault();

            return _GlassData.FirstOrDefault(d=>d.HPanelId == glassId);
        }

        public void AddGlassData(GlassData glassData)
        {
            if (_GlassData.Count > 0)
                return;

            _GlassData.Add(glassData);

            OnGlassDataAdded(glassData);

            if (_GlassData.Count > 0)
            {
                Prst = Prst.Execute;
            }
        }

        public void RemoveGlassData(string glassId = null)
        {
            var glassData = GetGlassData(glassId);
            if (glassData == null)
                return;

            if (_GlassData.Remove(glassData))
            {
                OnGlassDataRemoved(glassData);
            }

            if (_GlassData.Count < 1)
            {
                Prst = Prst.Idle;
            }
        }

        public void CompleteProcess()
        {
            ProcessDone?.Invoke();
        }

        #endregion

    }
}
