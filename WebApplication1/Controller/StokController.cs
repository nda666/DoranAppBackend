using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Dtos.Stok;
using Microsoft.AspNetCore.Mvc.Filters;
using DoranOfficeBackend.Dtos.Transaksi;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml;
using MySqlX.XDevAPI.Common;
using ConsoleDump;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class StokController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        public StokController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private async Task<List<GetStokMassResponseDto>> RunGetStokQueryMass(GetStokMassRequestDto dto) 
        {
            var result = (
     await (from bm in _context.Barangmasuk
            where bm.KodeBarang == dto.KodeBarang
            select new { Jumlah = (int?)bm.Jumlah ?? 0, KodeGudang = bm.Kodegudang }).ToListAsync()
 )
 .Concat(
 await (
     from ht in _context.Htrans
     join dt in _context.Dtrans on ht.KodeH equals dt.Kodeh
     where dt.Kodebarang == dto.KodeBarang
     select new { Jumlah = dt.KuranginStok ? dt.Jumlah * -1 : 0, KodeGudang = ht.Kodegudang }
     ).ToListAsync()
 ).Concat(
     await (from ht in _context.Htransit
            join dt in _context.Dtransit on ht.KodeT equals dt.Kodet
            where dt.Kodebarang == dto.KodeBarang
            select new { Jumlah = (int)dt.Jumlah, KodeGudang = (int)ht.KodeGudangTujuan }).ToListAsync()
 )
 .Concat(
    await (from ht in _context.Htransit
           join dt in _context.Dtransit on ht.KodeT equals dt.Kodet
           where dt.Kodebarang == dto.KodeBarang
           select new { Jumlah = (int)dt.Jumlah * -1, KodeGudang = (int)ht.Kodegudang }).ToListAsync()
 )

 .GroupBy(e => e.KodeGudang)
 .Where(e => dto.Kodegudang.Contains(e.Key))
 .Select(g => new GetStokMassResponseDto { KodeGudang = g.Key, TotalJumlah = g.Sum(e => e.Jumlah) })
 .Join(_context.Mastergudang, e => e.KodeGudang, e => e.Kode, (e, x) => new GetStokMassResponseDto
  {
      KodeGudang = e.KodeGudang,
      TotalJumlah = e.TotalJumlah,
      NamaGudang = x.Nama
 })
 .ToList();
            return result;
        }

        private async Task<int> RunGetStokQuery(GetStokRequestDto dto)
        {
            int result = 0;
            if (dto.Kodegudang != 0)
            {
                result = await (
                       from a in _context.Barangmasuk
                       where a.Kodegudang == dto.Kodegudang && a.KodeBarang == dto.KodeBarang
                       select (int?)a.Jumlah ?? 0
                   ).SumAsync() -
                   await (
                       from h in _context.Htrans
                       join d in _context.Dtrans on h.KodeH equals d.Kodeh
                       join p in _context.Masterpelanggan on h.KodePelanggan equals p.Kode
                       where h.Kodegudang == dto.Kodegudang && d.Kodebarang == dto.KodeBarang
                       select d.KuranginStok ? d.Jumlah : 0
                   ).SumAsync() +
                   await (
                       from ht in _context.Htransit
                       join dt in _context.Dtransit on ht.KodeT equals dt.Kodet
                       where ht.KodeGudangTujuan == dto.Kodegudang && dt.Kodebarang == dto.KodeBarang
                       select (int?)dt.Jumlah ?? 0
                   ).SumAsync() -
                   await (
                       from ht in _context.Htransit
                       join dt in _context.Dtransit on ht.KodeT equals dt.Kodet
                       where ht.Kodegudang == dto.Kodegudang && dt.Kodebarang == dto.KodeBarang
                       select (int?)dt.Jumlah ?? 0
                   ).SumAsync();
            }
            else
            {
                result = await (
                   from a in _context.Barangmasuk
                   where a.Kodegudang == dto.Kodegudang && a.KodeBarang == dto.KodeBarang
                   select (int?)a.Jumlah ?? 0
               ).SumAsync() -
               await (
                   from h in _context.Htrans
                   join d in _context.Dtrans on h.KodeH equals d.Kodeh
                   join p in _context.Masterpelanggan on h.KodePelanggan equals p.Kode
                   where h.Kodegudang == dto.Kodegudang && d.Kodebarang == dto.KodeBarang
                   select d.KuranginStok ? d.Jumlah : 0
               ).SumAsync();
            }
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<GetStokResponseDto>> GetStokByBarangAndGudang([FromQuery] GetStokRequestDto dto)
        {
            int stok = await RunGetStokQuery(dto);
            int? stokSby = null;
            if (dto.Kodegudang == 1)
            {
                stokSby = await RunGetStokQuery(new GetStokRequestDto
                {
                    Kodegudang = 134,
                    KodeBarang = dto.KodeBarang
                });
            }
            return Ok(new GetStokResponseDto
            {
                stok = stok,
                stokSby = dto.Kodegudang == 1 ? stokSby : null
            });

        }

        [HttpPost("mass")]
        public async Task<ActionResult<List<GetStokMassResponseDto>>> GetStokByBarangAndGudangMass([FromBody] GetStokMassRequestDto dto)
        {
            var res = await RunGetStokQueryMass(dto);
            res?.Dump();
            return res;

        }

        [HttpGet("mutasi")]
        public async Task<ActionResult<IEnumerable<GetMutasiResultDto>>> GetMutasi([FromQuery] FintMutasiDto dto)
        {
            var result = (
    from t1 in (
        // Subquery 1
        from bm in _context.Barangmasuk
        join s in _context.Mastersupplier on bm.KodeSupplier equals s.SupplierKode
        where bm.KodeBarang == dto.KodeBarang && bm.Kodegudang == dto.Kodegudang
        select new
        {
            Tanggal = bm.TglMasuk,
            Keterangan = Convert.ToString("IN - " + bm.Keterangan),
            Oleh = Convert.ToString(s.SupplierNama),
            Harga = Convert.ToInt32(bm.Harga),
            Jumlah = Convert.ToInt32(bm.Jumlah),
            Saldo = Convert.ToInt32(0),
            Indexnya = Convert.ToInt32(1),
            KODEnya = Convert.ToInt32(bm.Kode),
            KodeSupplier = Convert.ToInt32(bm.KodeSupplier),
            KodeBarang = Convert.ToInt32(bm.KodeBarang),
            History = Convert.ToString(bm.HistoryNya),
            Lunas = Convert.ToString("2")
        }
            )
            .Union(
        // Subquery 2
        from ht in _context.Htransit
        join g in _context.Mastergudang on ht.Kodegudang equals g.Kode
        join dt in _context.Dtransit on ht.KodeT equals dt.Kodet
        where dt.Kodebarang == dto.KodeBarang && ht.KodeGudangTujuan == dto.Kodegudang
        select new
        {
            Tanggal = ht.TglTrans ?? DateTime.Now,
            Keterangan = Convert.ToString("IN - " + ht.Keterangan),
            Oleh = Convert.ToString("GUDANG " + g.Nama),
            Harga = Convert.ToInt32(0), // Adjust this part according to your actual logic
            Jumlah = Convert.ToInt32(dt.Jumlah),
            Saldo = Convert.ToInt32(0),
            Indexnya = Convert.ToInt32(2),
            KODEnya = Convert.ToInt32(ht.KodeT),
            KodeSupplier = Convert.ToInt32(ht.Kodegudang ?? 0),
            KodeBarang = Convert.ToInt32(dt.Kodebarang),
            History = Convert.ToString(ht.HistoryNya ?? ""),
            Lunas = Convert.ToString("2")
        }
            )
                .Union(
            // Subquery 3
            from ht in _context.Htransit
            join g in _context.Mastergudang on ht.KodeGudangTujuan equals g.Kode
            join dt in _context.Dtransit on ht.KodeT equals dt.Kodet
            where dt.Kodebarang == dto.KodeBarang && ht.Kodegudang == dto.Kodegudang
            group new { ht, dt } by new { ht.TglTrans, ht.Keterangan, g.Nama } into grouped
            select new
            {
                Tanggal = grouped.Key.TglTrans ?? DateTime.Now,
                Keterangan = Convert.ToString("OUT - " + grouped.Key.Keterangan),
                Oleh = Convert.ToString("GUDANG " + grouped.Key.Nama),
                Harga = Convert.ToInt32(0), // Adjust this part according to your actual logic
                Jumlah = Convert.ToInt32(-1 * grouped.Sum(x => x.dt.Jumlah)),
                Saldo = Convert.ToInt32(0),
                Indexnya = Convert.ToInt32(4),
                KODEnya = Convert.ToInt32(grouped.First().ht.KodeT),
                KodeSupplier = Convert.ToInt32(grouped.First().ht.Kodegudang),
                KodeBarang = Convert.ToInt32(grouped.First().dt.Kodebarang),
                History = Convert.ToString(grouped.First().ht.HistoryNya ?? ""),
                Lunas = Convert.ToString("2")
            }
        ).Union(
            // Subquery 4
            from h in _context.Htrans
            join d in _context.Dtrans on h.KodeH equals d.Kodeh
            join p in _context.Masterpelanggan on h.KodePelanggan equals p.Kode
            join k in _context.LokasiKota on p.Kota equals k.Kode
            where d.Kodebarang == dto.KodeBarang && h.Kodegudang == dto.Kodegudang
            group new { h, d } by new { h.TglTrans, h.Keterangan, p.Nama, p.Lokasi, d.Harga, h.KodeH, p.Kode, d.Kodebarang, h.HistoryNya, h.Lunas } into grouped
            select new
            {
                Tanggal = grouped.Key.TglTrans,
                Keterangan = Convert.ToString("OUT - " + grouped.Key.Keterangan),
                Oleh = Convert.ToString(grouped.Key.Nama + " - " + grouped.Key.Lokasi),
                Harga = Convert.ToInt32(grouped.Key.Harga),
                Jumlah = Convert.ToInt32(-1 * grouped.Sum(x => (bool)x.d.KuranginStok ? x.d.Jumlah : 0)),
                Saldo = Convert.ToInt32(0),
                Indexnya = Convert.ToInt32(3),
                KODEnya = Convert.ToInt32(grouped.Key.KodeH),
                KodeSupplier = Convert.ToInt32(grouped.Key.Kode),
                KodeBarang = Convert.ToInt32(grouped.Key.Kodebarang),
                History = Convert.ToString(grouped.Key.HistoryNya),
                Lunas = Convert.ToString(grouped.Key.Lunas)
            }
        )
    select new GetMutasiResultDto
    {
        Indexnya = Convert.ToInt32(t1.KODEnya),
        Tanggal = t1.Tanggal,
        Keterangan = t1.Keterangan,
        Oleh = t1.Oleh,
        Harga = t1.Harga,
        Jumlah = t1.Jumlah,
        Saldo = Convert.ToInt32(t1.Saldo),
        KODEnya = t1.KODEnya,
        KodeSupplier = t1.KodeSupplier,
        KodeBarang = t1.KodeBarang,
        History = t1.History,
        Lunas = t1.Lunas
    }
).OrderBy(t1 => t1.Tanggal).ThenBy(t1 => t1.Indexnya);
            return Ok(await result.ToListAsync());
        }



    }


}
