using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public static class DeviceContainerHelper
    {
        public static List<short> GetBatchWriteValues(WordDeviceContainer wordContainer)
        {
            var orderByAddress = wordContainer.OfType<WordDevice>().OrderBy(d => d.Address);
            var firstDev = orderByAddress.FirstOrDefault();
            var writeValue = new List<short>(firstDev.WriteBufferData);

            foreach (var afterDev in orderByAddress.Skip(1))
            {
                var difference = writeValue.Count - afterDev.Address;
                // 추가될 데이터의 시작 주소가 이전 데이터와 겹칠 경우
                if (difference > 0)
                {
                    writeValue.RemoveRange(afterDev.Address - 1, difference);
                }
                // 추가될 데이터의 시작 주소가 이전 데이터 마지막 주소와 1 이상 차이날 경우
                else if (difference < 0)
                {
                    writeValue.AddRange(new short[difference * -1]);
                }

                writeValue.AddRange(afterDev.WriteBufferData);
            }

            return writeValue;
        }


    }
}