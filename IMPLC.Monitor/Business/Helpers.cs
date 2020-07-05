using System.Globalization;

namespace IMPLC.Monitor
{
    // TODO: 우아하게 다시 만들기...
    public static class DeviceHelper
    {
        public static bool IsDeviceText(string value)
        {
            if (value.Length < 2)
                return false;

            var deviceText = value.Substring(0, 1).ToUpper();
            var addressText = value.Substring(1, value.Length - 1);
                
            return
                (deviceText == "W" 
                || deviceText == "B")
                && int.TryParse(addressText, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int result);
        }

        public static string ConvertDeviceText(string value)
        {
            if (IsDeviceText(value) == false)
                return null;

            var device = value.Substring(0, 1).ToUpper();
            var address = int.Parse(value.Substring(1, value.Length - 1), NumberStyles.HexNumber);

            return $"{device}{address:X5}";
        }

    }
}