using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace ÖdevBilgisayar
{
    internal class EkranKartı:Bilgisayar
    {
        string connection = ConfigurationManager.ConnectionStrings["Bilgisayar"].ConnectionString;

        public long EkranKartId { get; set; }
        public long IslemciId { get; set; }
        public long RamId { get; set; }
        public long EkranId { get; set; }
        public long DiskId { get; set; }
        public long AnakartId { get; set; }
        public double fiyat { get; set; }

        public EkranKartı(long bilgisayarId, byte[] resim ,long ekrankartıd, long islemciıd, long ramıd, long ekranıd, long diskıd, long anakartId)
        : base(bilgisayarId,resim)
        {
            //Kalıtımdan dolayı bilgisayarıd ve resim tekrar tanımlanmadı. :base komutu ile tanımlandı Bilgisayar Classında tanımlandı.

            EkranKartId = ekrankartıd;
            IslemciId = islemciıd;
            RamId = ramıd;
            EkranId = ekranıd;
            DiskId = diskıd;
            AnakartId = anakartId;
            fiyat = 9000.00;
        }
        public void ekle()
        {

       
            string str = "insert into Ürünler(BilgisayarId,EkranKartId,IslemciId,RamId,EkranId,AnaKartId,DiskId,Resim,Fiyat) values(@bilgisayar,@ekrankartı,@islemci,@ram,@ekran,@anakart,@disk,@resim,@fiyat)";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@bilgisayar", BilgisayarId); // Kalıtımdan dolayı yeniden bilgisayarıd tanımlamadan kullanabildim.
            cmd.Parameters.AddWithValue("@ekrankartı", EkranKartId);
            cmd.Parameters.AddWithValue("@islemci", IslemciId);
            cmd.Parameters.AddWithValue("@ram", RamId);
            cmd.Parameters.AddWithValue("@ekran", EkranId);
            cmd.Parameters.AddWithValue("@anakart", AnakartId);
            cmd.Parameters.AddWithValue("@disk", DiskId);
            cmd.Parameters.Add("@resim", System.Data.SqlDbType.Image,Resim.Length).Value = Resim;
            cmd.Parameters.AddWithValue("@fiyat", fiyatHesap(fiyat));
            cmd.ExecuteNonQuery();
           

        }
        public double fiyatHesap(double fiyat)
        {
            double zam = 0;
            
            switch (IslemciId)
            {
                case 1:
                    if (BilgisayarId == 1)
                    {
                        zam = fiyat * 0.1;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 2)
                    {
                        zam = fiyat * 0.09;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 3)
                    {
                        zam = fiyat * 0.13;
                        fiyat += zam;

                    }
                    else if (BilgisayarId == 4)
                    {
                        zam = fiyat * 0.15;
                        fiyat += zam;
                    }

                    break;
                case 2:
                    if (BilgisayarId == 3)
                    {
                        zam = fiyat * 0.30;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 4)
                    {
                        zam = fiyat * 0.5;
                        fiyat += zam;
                    }
                    break;

            }
            switch (AnakartId)
            {
                case 1:
                    if(BilgisayarId == 2)
                    {
                        zam = fiyat * 0.03;
                        fiyat += zam;
                    }
                    else if(BilgisayarId == 4)
                    {
                        zam = fiyat * 0.04;
                        fiyat += zam;
                    }
                    break;
                case 2:
                    if(BilgisayarId == 1)
                    {
                        zam = fiyat * 0.2;
                        fiyat += zam;

                    }
                    else if(BilgisayarId == 3)
                    {
                        zam = fiyat * 0.07;
                        fiyat += zam;
                    }
                    break;
                case 4:
                    if(BilgisayarId == 2)
                    {
                        zam = fiyat * 0.13;
                        fiyat += zam;
                    }
                    else if( BilgisayarId == 3)
                    {
                        zam = fiyat * 0.4;
                        fiyat += zam;
                    }
                    break;
            }
            switch (EkranKartId)
            {
                case 2:
                    if(BilgisayarId == 1)
                    {
                        zam = fiyat * 0.1;
                        fiyat += zam;
                    }
                    else if(BilgisayarId == 3)
                    {
                        zam = fiyat * 0.12;
                        fiyat += zam;
                    }

                    break;
                case 1:
                    if(BilgisayarId == 2)
                    {
                        zam = fiyat * 0.09;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 4)
                    {
                        zam = fiyat * 0.1;
                        fiyat += zam;
                    }
                  
                    break;
                case 3:
                    if(BilgisayarId == 1)
                    {
                        zam = fiyat * 0.05;
                        fiyat += zam;
                    }
                    else if( BilgisayarId == 2) 
                    {
                        zam = fiyat * 0.06;
                        fiyat += zam;
                    }
                    else if(BilgisayarId == 4)
                    {
                        zam = fiyat * 0.04;
                        fiyat += zam;
                    }
                    break;
            }
            switch (RamId)
            {
                case 1:
                    if (BilgisayarId == 1)
                    {
                        zam = fiyat * 0.05;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 2)
                    {
                        zam = fiyat * 0.06;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 4)
                    {
                        zam = fiyat * 0.04;
                        fiyat += zam;
                    }
                    break;
                case 3:
                    if (BilgisayarId == 1)
                    {
                        zam = fiyat * 0.08;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 2)
                    {
                        zam = fiyat * 0.03;
                        fiyat += zam;
                    }
                    else if (BilgisayarId == 3)
                    {
                        zam = fiyat * 0.04;
                        fiyat += zam;
                    }
                    else
                    {
                        zam = fiyat * 0.04;
                        fiyat += zam;
                    }
                    break;
                case 4:
                    if(BilgisayarId == 1)
                    {
                        zam = fiyat * 0.1;
                        fiyat += zam;
                    }
                    else if(BilgisayarId == 4)
                    {
                        zam = fiyat * 0.04;
                        fiyat += zam;
                    }
                    else if(BilgisayarId == 3)
                    {
                        zam = fiyat * 0.09;
                        fiyat += zam;
                    }
                    break;

            }
            return fiyat;
        }
       
    }
}
