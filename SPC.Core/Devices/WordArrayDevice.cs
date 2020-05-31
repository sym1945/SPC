using System.Collections.Generic;

namespace SPC.Core
{
    public abstract class WordArrayDevice<T> : WordDevice
        where T : struct
    {
        #region Public Properties

        public abstract IEnumerable<T> Value { get; set; }

        #endregion


        #region Public Methods

        public abstract T GetValue(int index);

        public abstract void SetValue(int index, T value);

        public abstract void WriteValue(IEnumerable<T> value);

        public override void Execute(object parameter = null)
        {
            try
            {

            }
            catch
            {
                //TODO: Write Log
            }
        }

        #endregion


        #region Internal Methods

        internal override void OnRawDataChanged()
        {
            OnPropertyChanged(nameof(Value));
        }

        #endregion
    }
}
