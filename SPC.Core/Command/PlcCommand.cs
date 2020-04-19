namespace SPC.Core
{
    public class PlcCommand
    {
        /// <summary>
        /// Target Device Container Key
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Target Device Key
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// Execute Command Trigger Condition
        /// </summary>
        public CommandTrigger Trigger { get; set; }

        /// <summary>
        /// Execute Command Name
        /// </summary>
        public string Command { get; set; }

    }
}
