using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT {
    public delegate void FireEventHandler(object sender, FireEventArgs e);

    public class NewTown {
        private string townname;
        private int buildings;
        private int days;
        private Police policeman;
        private Ambulance ambulanceman;
        private FireDetect fireman;

        public event FireEventHandler Fire;
        private string[] resultservice;
        private Random rnd = new Random();
        private double fireprobability;

        public NewTown(string name, int buildings, int days) {
            townname = name;
            this.buildings = buildings;
            this.days = days;
            fireprobability = 1e-3;

            policeman = new Police(this);
            ambulanceman = new Ambulance(this);
            fireman = new FireDetect(this);

            policeman.On();
            ambulanceman.On();
            fireman.On();
        }

        protected virtual void OnFire(FireEventArgs e) {
            const string MESSAGE_FIRE = "У мiстi {0} пожежа! Будинок {1}. День {2}-й";
            Console.WriteLine(string.Format(MESSAGE_FIRE, townname, e.Building, e.Day));

            if (Fire != null) {
                Delegate[] eventhandlers = Fire.GetInvocationList();
                resultservice = new string[eventhandlers.Length];
                int k = 0;

                foreach (FireEventHandler evhandler in eventhandlers) {
                    evhandler(this, e);
                    resultservice[k++] = e.Result;
                }
            }
        }

        public void LifeOurTown() {
            const string OK = "У мiстi {0} усi спокiйно! Пожеж не було.";
            bool wasfire = false;

            for (int day = 1; day <= days; day++) {
                for (int building = 1; building <= buildings; building++) {
                    if (rnd.NextDouble() < fireprobability) {
                        FireEventArgs e = new FireEventArgs(building, day);
                        OnFire(e);
                        wasfire = true;
                        for (int i = 0; i < resultservice.Length; i++) {
                            Console.WriteLine(resultservice[i]);
                        }
                    }
                }
            }

            if (!wasfire) {
                Console.WriteLine(string.Format(OK, townname));
            }
        }
    }

    public abstract class Receiver {
        protected NewTown town;
        protected Random rnd = new Random();

        public Receiver(NewTown town) {
            this.town = town;
        }

        public void On() {
            town.Fire += new FireEventHandler(It_is_Fire);
        }

        public void Off() {
            town.Fire -= new FireEventHandler(It_is_Fire);
        }

        public abstract void It_is_Fire(object sender, FireEventArgs e);
    }

    public class Police : Receiver {
        public Police(NewTown town) : base(town) { }

        public override void It_is_Fire(object sender, FireEventArgs e) {
            const string OK = "Мiлiцiя знайшла винних!";
            const string NOK = "Мiлiцiя не знайшла винних! Наслiдок триває.";

            if (rnd.Next(0, 10) > 6) {
                e.Result = OK;
            } else {
                e.Result = NOK;
            }
        }
    }

    public class FireDetect : Receiver {
        public FireDetect(NewTown town) : base(town) { }

        public override void It_is_Fire(object sender, FireEventArgs e) {
            const string OK = "Пожежнi згасили пожежу!";
            const string NOK = "Пожежа триває! Потрiбна допомога.";

            if (rnd.Next(0, 10) > 4) {
                e.Result = OK;
            } else {
                e.Result = NOK;
            }
        }
    }

    public class Ambulance : Receiver {
        public Ambulance(NewTown town) : base(town) { }

        public override void It_is_Fire(object sender, FireEventArgs e) {
            const string OK = "Швидка надала допомогу!";
            const string NOK = " Є постраждалi! Потрiбнi лiки.";

            if (rnd.Next(0, 10) > 2) {
                e.Result = OK;
            } else {
                e.Result = NOK;
            }
        }
    }

    public class FireEventArgs : EventArgs {
        int building;
        int day;
        string result;

        public int Building { get { return building; } }
        public int Day { get { return day; } }
        public string Result { get { return result; } set { result = value; } }

        public FireEventArgs(int building, int day) {
            this.building = building;
            this.day = day;
        }
    }
}
