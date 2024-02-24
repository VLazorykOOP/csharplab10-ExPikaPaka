using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT {
    public class City {
        public event EventHandler<CrimeEventArgs> CrimeReported;

        public void ReportCrime(string location, string description) {
            OnCrimeReported(new CrimeEventArgs(location, description));
        }

        protected virtual void OnCrimeReported(CrimeEventArgs e) {
            CrimeReported?.Invoke(this, e);
        }
    }

    public class CrimeEventArgs : EventArgs {
        public string Location { get; }
        public string Description { get; }

        public CrimeEventArgs(string location, string description) {
            Location = location;
            Description = description;
        }
    }
}
