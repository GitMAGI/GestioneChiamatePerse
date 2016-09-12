﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestServizio
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Avvio test ...");

            WSChiamatePerse.ChiamataSOi testR = new WSChiamatePerse.ChiamataSOi();
            testR.CognomeChiamata = "Boriellieri";
            testR.NomeChiamata = "Marcella";
            testR.NumeroChiamata = "44222390";
            testR.MotivoChiamata = "Reclamo!";
            testR.ExtIDChiamata = null;
            testR.DataOraInizioChiamata = Convert.ToDateTime("2015-11-21 14:07:47");
            testR.DataOraFineChiamata = Convert.ToDateTime("2015-1-21 14:13:14");
            testR.Priorita = 1;
            testR.ExtIDOperatore = 3209;

            WSChiamatePerse.GestioneChiamateClient client = new WSChiamatePerse.GestioneChiamateClient();

            WSChiamatePerse.ResponseInsert rsp = client.InserisciChiamateOO(testR);

            System.Console.WriteLine("Test Concluso. Premere un tasto per terminare!");
            System.Console.ReadKey();
        }
    }
}
