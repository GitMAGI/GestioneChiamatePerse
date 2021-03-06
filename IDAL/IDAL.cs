﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.VO;

namespace IDAL
{
    public interface IDAL
    {
        List<ChiamataVO> GetChiamateByRangeDate(DateTime begin, DateTime end);
        List<ChiamataVO> GetChiamateAll();
        ChiamataVO GetChiamataByPk(long idid);
        ChiamataVO GetChiamataByExtPk(long extidid);
        List<ChiamataVO> GetChiamateByExtPk(List<long> extidids);
        List<ChiamataVO> GetChiamateByStato(int stato);
        int UpdateChiamataByExtPk(ChiamataVO data, long extidid);
        int UpdateChiamataByPk(ChiamataVO data, long idid);
        int AddChiamata(ChiamataVO data);
        int AddChiamate(List<ChiamataVO> data);
        int DeleteChiamata(long chiamidid);
    }
}
