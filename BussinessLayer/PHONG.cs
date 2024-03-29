﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class PHONG
    {
        Entities db;
        public PHONG()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_Phong> getAll()
        {
            return db.tb_Phong.ToList();
        }

        public List<tb_Tang> getByTenTang()
        {
            return db.tb_Tang.ToList();
        }
        
        public List<tb_Phong> getByTenTangLoad()
        {
            return db.tb_Phong.ToList() ;
        }

        public List<tb_Phong> getByTenTangLoad(int idtang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idtang).ToList();

        }

        public List<tb_LoaiPhong> getByLoaiPhong(int _loaiphong)
        {
            return db.tb_LoaiPhong.Where(x => x.IDLOAIPHONG == _loaiphong).ToList();
        }

        public List<tb_Phong> getByTang(int idTang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idTang).ToList();
        }

        public List<OBJ_PHONG> getListFull()
        {
            var lsPhong = db.tb_Phong.ToList();
            List<OBJ_PHONG> lsPhongOBJ = new List<OBJ_PHONG>();
            OBJ_PHONG phong;
            foreach (var _p in lsPhong)
            {
                phong = new OBJ_PHONG();
                phong.TENPHONG = _p.TENPHONG;
                phong.STATUS = bool.Parse(_p.STATUS.ToString());
                phong.DISABLED = bool.Parse(_p.DISABLED.ToString());
                phong.IDLOAIPHONG = _p.IDLOAIPHONG;
                phong.IDTANG = _p.IDTANG;
                var tang = db.tb_Tang.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
                phong.TENTANG = tang.TENTANG;
                var lp = db.tb_LoaiPhong.FirstOrDefault(l => l.IDLOAIPHONG == _p.IDLOAIPHONG);
                phong.TENLOAIPHONG = lp.TENLOAIPHONG;
                phong.DONGIA = double.Parse(lp.DONGIA.ToString());
            }
            return lsPhongOBJ;
        }

        public List<OBJ_PHONG> getAllByPhong(int _idPhong)
        {
            //var listDP = db.tb_Phong.Where(x => x.NGAYDATPHONG >= tungay && x.NGAYDATPHONG < denngay).ToList();
            var lst = db.tb_Phong.Where(x => x.IDTANG == _idPhong).ToList();
            List<OBJ_PHONG> lstDPSP = new List<OBJ_PHONG>();
            OBJ_PHONG sp;
            foreach (var item in lst)
            {
                sp = new OBJ_PHONG();
                sp.IDPHONG = item.IDPHONG;
                sp.TENPHONG = item.TENPHONG;
                sp.IDTANG = item.IDTANG;
                var s = db.tb_Tang.FirstOrDefault(x => x.IDTANG == item.IDTANG);
                sp.TENTANG = s.TENTANG;
                sp.DISABLED = item.DISABLED;
                sp.STATUS = item.STATUS;
                var l = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == item.IDLOAIPHONG);
                sp.TENLOAIPHONG = l.TENLOAIPHONG;
                lstDPSP.Add(sp);
            }
            return lstDPSP;
        }

        public  OBJ_PHONG getItemFull(int _idPhong)
        {
            var _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == _idPhong);
            OBJ_PHONG phong = new OBJ_PHONG();
            phong.IDPHONG = _p.IDPHONG;
            phong.TENPHONG = _p.TENPHONG;
            phong.STATUS = bool.Parse(_p.STATUS.ToString());
            phong.DISABLED = bool.Parse(_p.DISABLED.ToString());
            phong.IDLOAIPHONG = _p.IDLOAIPHONG;
            phong.IDTANG = _p.IDTANG;
            var tang = db.tb_Tang.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
            phong.TENTANG = tang.TENTANG;
            var lp = db.tb_LoaiPhong.FirstOrDefault(l =>l.IDLOAIPHONG==_p.IDLOAIPHONG);
            phong.TENLOAIPHONG = lp.TENLOAIPHONG;
            phong.DONGIA = double.Parse(lp.DONGIA.ToString());
            return phong;
        }

        public void add(tb_Phong phong)
        {
            try
            {
                db.tb_Phong.Add(phong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_Phong phong)
        {
            tb_Phong _kh = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == phong.IDPHONG);
            _kh.TENPHONG = phong.TENPHONG;
            _kh.STATUS = phong.STATUS;
            _kh.IDTANG = phong.IDTANG;
            _kh.IDLOAIPHONG = phong.IDLOAIPHONG;
            _kh.DISABLED = phong.DISABLED;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }

        public void updateStatus(int id,bool status)
        {
            tb_Phong p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == id);
            p.STATUS = status;
            db.SaveChanges();
        }

        public void delete(int idphong)
        {
            tb_Phong _kh = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == idphong);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi rồi bạn ơi" + ex.Message);
            }
        }
        public bool checkEmpty(int idPhong)
        {
            var p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == idPhong);
            if (p.STATUS == true)
                return true;
            else
                return false;
        }
    }
}
