using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_task1.Models
{
    public class Network
    {
        private string ssid;
        private int signalLevel;
        public string Ssid
        {
            get { return ssid; }
        }

        public int SignalLevel
        {
            get { return signalLevel; }
        }
        public Network(string ssid, int signalLevel)
        {
            this.ssid = ssid;
            this.signalLevel = signalLevel;
        }
        public override string ToString()
        {
            return $"SSID: {ssid.ToString()} signalLever: {signalLevel.ToString()}";
        }

    }
}
