using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    /// <summary>
    /// 특정 Device를 찾기 위해 Container, Device key를 갖고 있는 데이터 전달자
    /// </summary>
    public class DeviceFindKey
    {
        #region Public Properties

        /// <summary>
        /// Target Container Key
        /// </summary>
        public string Container { get; private set; }

        /// <summary>
        /// Target Device Key
        /// </summary>
        public string Device { get; private set; }

        #endregion


        #region Constructor

        public DeviceFindKey(string container, string device)
        {
            Container = container;
            Device = device;
        }

        #endregion

    }
}
