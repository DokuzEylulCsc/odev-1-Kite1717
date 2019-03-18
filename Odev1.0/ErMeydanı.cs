using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace Odev1._0
{
   
    public  class ErMeydanı
    {
        public  void startPlaying()
        {

            
            List<Asker> team1 = new List<Asker>();
            List<Asker> team2 = new List<Asker>();

            Takım takım = new Takım();
            team1 = takım.createTeam(1);

            Takım takım2 = new Takım();
            team2 = takım2.createTeam(2);

            Random random = new Random();
            byte x = (byte)random.Next(0, 4);
            List<Loca> locas = new List<Loca>();
               locas = positionPackage(x);
            int i = 0;
            foreach(Asker asker in team1)
            {
                asker.Konumlandır((byte)locas[i].x, (byte)locas[i].y);
                i++;

            }
            locas = new List<Loca>();
            i = 0;
            if (x == 0) locas = positionPackage(1);
            else if (x == 1) locas = positionPackage(0);
            else if (x == 2) locas = positionPackage(3);
            else if (x == 3) locas = positionPackage(2);
            foreach (Asker asker in team2)
            {
                asker.Konumlandır((byte)locas[i].x, (byte)locas[i].y);
                i++;

            }
            Console.WriteLine("Teams preparing...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Teams ready");

            Console.WriteLine("\n" + takım.getName());
            foreach(Asker asker in team1)
               Console.WriteLine( asker.ToString());
            Console.WriteLine("\n" + takım2.getName());
            foreach (Asker asker in team2)
                Console.WriteLine(asker.ToString());


            Console.WriteLine("The war is beginning...");
            System.Threading.Thread.Sleep(1000);

            int c;
            bool quit = false;
            bool isFirst = true;
            int k;
            string message;
            while(!quit)
            { 
               
                c = random.Next(0, 7);

                if(isFirst)
                {

                   k = team1[c].Eylem();
                    if(k == 1)
                    {
                        
                           team1[c].Bekle();
                        message = "The " + (c + 1) + ". " + team1[c].getStatus() + "chose to maintain its position in the first team";
                        dosyayaYaz(message);
                    }
                   else if(k == 2)
                    {

                        
                       message =  team1[c].HareketEt();
                        dosyayaYaz(message);
                    }
                    else if(k == 3)
                    {
                        byte count;
                        count = team1[c].AtesEt();
                        foreach (Asker asker in team2)
                        {
                            if ("Er".Equals(team1[c].getStatus()))
                                { 
                            if ((team1[c].point.X + 1 == asker.point.X && team1[c].point.Y + 1 == asker.point.Y) ||
                                (team1[c].point.X == asker.point.X && team1[c].point.Y + 1 == asker.point.Y) ||
                                (team1[c].point.X - 1 == asker.point.X && team1[c].point.Y + 1 == asker.point.Y) ||
                                 (team1[c].point.X - 1 == asker.point.X && team1[c].point.Y == asker.point.Y) ||
                                 (team1[c].point.X - 1 == asker.point.X && team1[c].point.Y - 1 == asker.point.Y) ||
                                  (team1[c].point.X == asker.point.X && team1[c].point.Y - 1 == asker.point.Y) ||
                                 (team1[c].point.X + 1 == asker.point.X && team1[c].point.Y - 1 == asker.point.Y) ||
                                 (team1[c].point.X + 1 == asker.point.X && team1[c].point.Y == asker.point.Y))
                            {
                                asker.SetHeal(count);
                                    message = "The damage :  " + count + "- >> from the first team " +
                                        "The " + (c + 1) + ". " + team1[c].getStatus() + " to  " + "from the second team " + asker.getStatus();
                                    dosyayaYaz(message);

                            }
                        }






                        }
                        


                    }


                }












                if (team1.Count == 0 || team2.Count == 0)
                    quit = true;
            }

        }
        public void dosyayaYaz(string s)
        {
            string dosya_yolu = @"C:\similation.txt";
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.Write(s);
            //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik.
        }

        private List<Loca> positionPackage(int loca)
        {
            List<Loca> locas = new List<Loca>();
            int x = 0, y = 0, alt, ust, count = 0; ;
            bool check = true;
            Random random = new Random();

            if (loca == 0) // sol alt
            {
                while (count != 7)
                {
                    x = random.Next(0, 5);  // 0-4
                    y = random.Next(0, 5); // 0-4
                    for (int i = 0; i < locas.Count; i++)
                    {
                        if (locas[i].x == x && locas[i].y == y)
                        {
                            check = false;
                            break;
                        }

                    }
                    if (check)
                    {
                        locas.Add(new Loca(x, y));
                        count++;

                    }
                    check = true;
                }
            }
            
            else if (loca == 1) // sag ust
            {
                while(count != 7) { 
                x = random.Next(11, 16);  // 11 - 15
                y = random.Next(11, 16); // 11 -15
                for (int i = 0; i < locas.Count; i++)
                {
                    if (locas[i].x == x && locas[i].y == y)
                    {
                        check = false;
                        break;
                    }

                }
                if (check)
                {
                    locas.Add(new Loca(x, y));
                    count++;

                }
                check = true;
            }
            }

            else if (loca == 2) // sağ alt
            {
                while (count != 7)
                {
                    x = random.Next(11, 16);  // 11 -15
                    y = random.Next(0, 5); // 0-4
                    for (int i = 0; i < locas.Count; i++)
                    {
                        if (locas[i].x == x && locas[i].y == y)
                        {
                            check = false;
                            break;
                        }

                    }
                    if (check)
                    {
                        locas.Add(new Loca(x, y));
                        count++;

                    }
                    check = true;


                }
            }
            else if (loca == 3) // sol ust
            {


                while (count != 7)
                {
                    x = random.Next(0, 5);  // 0-4
                    y = random.Next(11, 16); // 11-15
                    for (int i = 0; i < locas.Count; i++)
                    {
                        if (locas[i].x == x && locas[i].y == y)
                        {
                            check = false;
                            break;
                        }

                    }
                    if (check)
                    {
                        locas.Add(new Loca(x, y));
                        count++;

                    }
                    check = true;

                }
            }
            return locas;
        }



        private class Loca
        {
            public int x, y;

            public Loca(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }

    }

   

}


