using System.Linq;
using System.Collections.Generic;
using System;

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

            return _GlassData.FirstOrDefault();
        }

        public void AddGlassData(GlassData glassData)
        {
            _GlassData.Add(glassData);

            OnGlassDataAdded(glassData);
        }

        public void RemoveGlassData(string glassId = null)
        {
            var glassData = GetGlassData(glassId);
            if (glassData == null)
                return;

            if (_GlassData.Remove(glassData))
            {
                OnGlassDataAdded(glassData);
            }
        } 

        #endregion

    }
}
