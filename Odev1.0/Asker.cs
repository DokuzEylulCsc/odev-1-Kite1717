using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1._0
{
    public abstract class Asker
    {
        public struct Location
        {
            public byte X, Y;

            public Location(byte x, byte y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        protected string status = null;
        protected bool isAlive;
        protected byte heal;
        public Location point ;


        public abstract byte GetHeal();
        public abstract string Konumlandır(byte x, byte y);
        public abstract bool SetHeal(byte damage);
        public abstract string getStatus();
        public abstract int Eylem();
        public abstract Location Bekle();
        public abstract string HareketEt();
        public abstract byte AtesEt();
    }

    public class Er : Asker
    {
        public Er()
        {
            this.status = "Er";
            this.isAlive = true;
            this.heal = 100;

        }
         
        
        public override int Eylem()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 10);
            if (x >= 0 && x < 3) // bekle %30
            {
                return 1;
            }
            else if (x >= 3 && x < 6) // hareket et %30
            {
                return 2;
            }
            else // ateş et %40
            {
                return 3;
            }



        }
        public override string Konumlandır(byte x, byte y)
        {
            if (x >= 0 && x <= 15 && y >= 0 && y <= 15)
            {
                this.point = new Location(x, y);
                
            }
            return "";
        }

        public override string ToString()
        {
            return this.status + " start position : " + "(" + this.point.X + "," + this.point.Y + ")";
        }

        public override bool SetHeal(byte damage)
        {
            if (this.heal - damage > 0)
                this.heal -= damage;
            else
            {
                this.heal = 0;
                this.isAlive = false;
                
            }
            return this.isAlive;

        }
        public override byte GetHeal()
        {
            return this.heal;
        }
        public override string getStatus()
        {
            return this.status;
        }



        public override byte AtesEt()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 3);
            // vereceği zarar miktarını döndürür
            if (x == 0)
                return 5;
            else if (x == 1)
                return 10;
            else return 15;
        }

        public override Location Bekle()
        {
            return this.point;
        }

        public override string HareketEt()
        {
            //sadece hareket işlemi burdan yap 
            // dışardan başka bi şekilde kontrol et o karede insan varmı diye

            Random random = new Random();
            byte uod = (byte)random.Next(0, 2);
            if (uod == 0) // yukarı yürüme
            {
                if (this.point.Y == 15 && this.point.X != 15) // sınıra gelmiş ise
                    this.point.X++;  // sağa git
                else if (this.point.Y == 15 && this.point.X == 15) // uçtaysa
                    return this.status + " new position : " + "(" + this.point.X + "," + this.point.Y + ")";

                else this.point.Y++;
            }
            else // aşağı yürüme
            {
                if (this.point.Y == 0 && this.point.X != 0) // sınıra gelmiş ise
                    this.point.X--; // sola git
                else if (this.point.Y == 0 && this.point.X == 0) // uçtaysa
                    return this.status + " new position : " + "(" + this.point.X + "," + this.point.Y + ")";

                else this.point.Y--;
            }
            return this.status + " new position : " + "(" + this.point.X + "," + this.point.Y + ")";
        }

    }


    public class Tegmen : Asker
    {
        public Tegmen()
        {
            this.status = "Tegmen";
            this.isAlive = true;
            this.heal = 100;
        }
        public override int Eylem()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 10);
            if (x >= 0 && x < 2) // bekle %20
            {
                return 1;
            }
            else if (x >= 2 && x < 5) // hareket et %30
            {
                return 2;
            }
            else // ateş et %50
            {
                return 3;
            }
        }
        public override string Konumlandır(byte x, byte y)
        {
            if (x >= 0 && x <= 15 && y >= 0 && y <= 15)
            {
                this.point = new Location(x, y);
            }
            return "";
        }

        public override string ToString()
        {
            return this.status + " start position : " + "(" + this.point.X + "," + this.point.Y + ")";
        }
        public override string getStatus()
        {
            return this.status;
        }



        public override bool SetHeal(byte damage)
        {
            if (this.heal - damage > 0)
                this.heal -= damage;
            else
            {
                this.heal = 0;
                this.isAlive = false;

            }
            return this.isAlive;

        }
        public override byte GetHeal()
        {
            return this.heal;
        }

        public override byte AtesEt()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 3);
            if (x == 0)
                return 10;
            else if (x == 1)
                return 20;
            else return 25;
        }

        public override Location Bekle()
        {
            return this.point;
        }

        public override string HareketEt()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 4);
            bool quit = false;
            while (!quit) // uygun hareket olana kadar deniyor
            {
                if (x == 0 && up()) // yukarı git
                    quit = true;
                else if (x == 1 && down()) // aşağı git
                    quit = true;
                else if (x == 2 && left()) // sola git
                    quit = true;
                else if (x == 3 && right()) // sağa git
                    quit = true;
                else x = (byte)random.Next(0, 4);
            }
            return this.status + " new position : " + "(" + this.point.X + "," + this.point.Y + ")";
        }
        private bool up()
        {
            if (this.point.Y == 15)
                return false;
            else this.point.Y++;
            return true;

        }
        private bool down()
        {
            if (this.point.Y == 0)
                return false;
            else this.point.Y--;
            return true;

        }
        private bool left()
        {
            if (this.point.X == 0)
                return false;
            else this.point.X--;
            return true;
        }
        private bool right()
        {
            if (this.point.X == 15)
                return false;
            else this.point.X++;
            return true;
        }
    }


    public class Yuzbasi : Asker
    {
        public Yuzbasi()
        {
            this.status = "Yuzbasi";
            this.isAlive = true;
            this.heal = 100;
        }
        public override int Eylem()
        {

            Random random = new Random();
            byte x = (byte)random.Next(0, 10);
            if (x >= 0 && x < 2) // bekle %20
            {
                return 1;
            }
            else if (x >= 2 && x < 6) // hareket et %40
            {
                return 2;
            }
            else // ateş et %40
            {
                return 3;
            }
        }


        public override string Konumlandır(byte x, byte y)
        {
            if (x >= 0 && x <= 15 && y >= 0 && y <= 15)
            {
                this.point = new Location(x, y);
            }
            return "";
        }

        public override string ToString()
        {
            return this.status + " start position : " + "(" + this.point.X + "," + this.point.Y + ")";
        }
        public override string getStatus()
        {
            return this.status;
        }

        public override bool SetHeal(byte damage)
        {
            if (this.heal - damage > 0)
                this.heal -= damage;
            else
            {
                this.heal = 0;
                this.isAlive = false;

            }
            return this.isAlive;

        }
        public override byte GetHeal()
        {
            return this.heal;
        }

        public override byte AtesEt()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 3);
            if (x == 0)
                return 15;
            else if (x == 1)
                return 25;
            else return 40;

        }

        public override Location Bekle()
        {
            return this.point;
        }

        public override string HareketEt()
        {
            Random random = new Random();
            byte x = (byte)random.Next(0, 8);
            bool quit = false;
            while (!quit) // uygun hareket eylemi gelene kadar
            {
                switch (x)
                {
                    case 0:
                        {
                            if (up()) // yukarı
                                quit = true;
                            break;
                        }
                    case 1:
                        {
                            if (down()) // aşağı
                                quit = true;
                            break;
                        }
                    case 2:
                        {
                            if (left()) // sola
                                quit = true;
                            break;
                        }
                    case 3:
                        {
                            if (right()) // sağa
                                quit = true;
                            break;
                        }
                    case 4:
                        {
                            if (leftDown()) //sol alt
                                quit = true;
                            break;
                        }
                    case 5:
                        {
                            if (rightDown()) //sağ alt
                                quit = true;
                            break;
                        }
                    case 6:
                        {
                            if (leftUp()) //sol üst
                                quit = true;
                            break;
                        }
                    case 7:
                        {
                            if (rightUp()) // sağ üst
                                quit = true;
                            break;
                        }
                    default:
                        {
                            x = (byte)random.Next(0, 8);
                            break;
                        }
                }
            }
            return this.status + " new position : " + "(" + this.point.X + "," + this.point.Y + ")";
        }

        private bool up()
        {
            if (this.point.Y == 15)
                return false;
            else this.point.Y++;
            return true;

        }
        private bool down()
        {
            if (this.point.Y == 0)
                return false;
            else this.point.Y--;
            return true;

        }
        private bool left()
        {
            if (this.point.X == 0)
                return false;
            else this.point.X--;
            return true;
        }
        private bool right()
        {
            if (this.point.X == 15)
                return false;
            else this.point.X++;
            return true;
        }
        private bool leftUp()
        {
            if (this.point.X - 1 < 0 || this.point.Y + 1 > 15)
                return false;
            else
            {
                this.point.X--;
                this.point.Y++;
            }
            return true;
        }
        private bool rightUp()
        {
            if (this.point.X + 1 > 15 || this.point.Y + 1 > 15)
                return false;
            else
            {
                this.point.X++;
                this.point.Y++;
            }
            return true;
        }
        private bool leftDown()
        {
            if (this.point.X - 1 < 0 || this.point.Y - 1 < 0)
                return false;
            else
            {
                this.point.X--;
                this.point.Y--;
            }
            return true;
        }
        private bool rightDown()
        {
            if (this.point.X + 1 > 15 || this.point.Y - 1 < 0)
                return false;
            else
            {
                this.point.X++;
                this.point.Y--;
            }
            return true;
        }

    }
}
