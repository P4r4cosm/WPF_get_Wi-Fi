using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_task1.Models
{
    public class Network
    {
       
        public DateTime ScanTime { get; private set; }

        public Network() { }
        public int Id {  get; set; }
        public string? Ssid
        {
            get; private set;
        }

        public int? SignalLevel
        {
            get; private set;
        }
        public Network(string ssid, int signalLevel=0)
        {
            Ssid = ssid;
            SignalLevel = signalLevel;
            ScanTime = DateTime.Now;
        }
        public override string ToString()
        {
            return $"SSID: {Ssid} signalLever: {SignalLevel.ToString()}";
        }

    }
}
