using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using DataAccessLayer;
using IBLL.DTO;
using Newtonsoft.Json;

namespace TesteServizio
{
    class Program
    {
        public static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {            
            log.Info("Avvio esecuzione Test ...");

            DAL dal = new DAL();
            BLL bll = new BLL(dal);
            /*
            string inizio = "2011-05-01 00:09:19";
            string fine = "2016-01-01 00:01:05";
            List<IDAL.VO.ChiamataVO> vos = dal.GetChiamateByRangeDate(Convert.ToDateTime(inizio), Convert.ToDateTime(fine));
            string jsonvos = JsonConvert.SerializeObject(vos);
            log.Debug(jsonvos);


            List<IBLL.DTO.ChiamataDTO> dtos = BusinessLogicLayer.Mappers.ChiamataMapper.JsonArrayToDTOList(jsonvos);
            int res = bll.AddChiamate(dtos);
            log.Debug(res);
            */
              
            log.Info("Test Terminato!");

            Console.WriteLine("Premere un tasto per terminare ....");
            Console.ReadKey();
        }
    }
}
