using System.util.zlib;
using System.Xml.Schema;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
{
    private readonly ApiFarmaciaContext _context;

    public MedicamentoRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicamento>> GetStockCincu()
    {   
        var medicamentosMenorCincu = await _context.Medicamentos
            .Where(p=>p.Inventario.Stock <=50)
            .ToListAsync();
        return medicamentosMenorCincu; 
    }

    public async Task<IEnumerable<Medicamento>> Get2024Expiracion()
    {   
        DateTime fechaLimite = new DateTime(2023, 12, 31);
        var medicamentosSinCaducar = await _context.Medicamentos.Where(m => m.FechaExpiracion <= fechaLimite).ToListAsync();
        return medicamentosSinCaducar;
    }

    public async Task<int> TotalVenParace()
    {
        var unidadesVendidas = await _context.MovimientosInventarios
            .Where(movimiento => movimiento.IdTipoMovimientoFk == 2)
            .Where(movimiento => movimiento.Inventario.Medicamentos.Any(medicamento => medicamento.Nombre == "Paracetamol"))
            .SumAsync(movimiento => movimiento.Cantidad);

        return unidadesVendidas;
    }

    public async Task<IEnumerable<Medicamento>> Get2024DespuExpiracion()
    {   
        var medicamentosExp2024 = await _context.Medicamentos
        .Where(m => m.FechaExpiracion.Year == 2024)
        .ToListAsync();
        return medicamentosExp2024;
    }    

    public async Task<int> GetTotalMedicVendidosMarzo()
    {
        DateTime fechaInicio = new DateTime(2023, 3, 1);
        DateTime fechaFin = new DateTime(2023, 3, 31);

        var totalMedicamentosVendidos = await _context.MovimientosInventarios
            .Where(movimiento => movimiento.IdTipoMovimientoFk == 2 &&
                                movimiento.FechaMovimiento >= fechaInicio &&
                                movimiento.FechaMovimiento <= fechaFin)
            .SumAsync(movimiento => movimiento.Cantidad);

        return totalMedicamentosVendidos;
    }

    public async Task<Medicamento> GetMediMenosVen2023()
    {
        var fechaInicio = new DateTime(2023, 1, 1);
        var fechaFin = new DateTime(2023, 12, 31);

        var medicamentoMenosVendido = await _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 2 && m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin)
            .GroupBy(m => m.IdInventarioFk)
            .OrderBy(g => g.Sum(m => m.Cantidad))
            .Select(g => g.FirstOrDefault().Inventario.Medicamentos).FirstOrDefaultAsync();

        return medicamentoMenosVendido.FirstOrDefault();
    }

    public async Task<Medicamento> GetMasCaro()
    {   
        var medicamentoMasCaro =  await _context.Medicamentos.OrderByDescending(m => m.Precio).FirstOrDefaultAsync();
        return medicamentoMasCaro;
    }
    public async Task<IEnumerable<Medicamento>> MedicamentosNuncaVendidos()
    {
        var MedicamentosVendidos = await _context.Medicamentos
        .Where(tn=> tn.Inventario.MovimientosInventario
        .Any(pm => pm.IdTipoMovimientoFk ==2))
        .ToListAsync();

        var MedicamentosNuncaVendidos = await _context.Medicamentos
        .Where(tn=> !MedicamentosVendidos.Contains(tn))
        .ToListAsync();

        return MedicamentosNuncaVendidos;
    }
    public async Task<int> TotalMedicamentosVendidosXmes2023(int mes)
    {
        var totalXmes = await _context.MovimientosInventarios
        .Where(ti=>ti.IdTipoMovimientoFk == 2 && ti.FechaMovimiento.Year == 2023 && ti.FechaMovimiento.Month == mes)
        .SumAsync(t=>t.Cantidad);        
        return totalXmes;
    }

    public async Task<IEnumerable<Medicamento>> MedicamentosVendidosXmes()
    {
        var Medicamentos = await _context.Medicamentos
        .Where(e => e.Inventario.MovimientosInventario
            .Where(mi => mi.IdTipoMovimientoFk == 2 && mi.FechaMovimiento.Year == 2023)
            .GroupBy(mi=> mi.FechaMovimiento.Month )
            .Count()==12)
            .ToListAsync();

        return Medicamentos;
    }
    public async Task<IEnumerable<Medicamento>> MedicamentosSinVenta2023()
    {
        var Medicamentos = await _context.Medicamentos
        .Where(f=> !f.Inventario.MovimientosInventario
            .Any(t=>t.IdTipoMovimientoFk ==2 && t.FechaMovimiento.Year == 2023))
            .ToListAsync();
            
        return Medicamentos;
    }
    public async Task<int> TotalMedicamentosVendidosTrimestre2023()
    {
        var primerTrimestreInicio = new DateTime(2023, 1, 1);
        var primerTrimestreFin = new DateTime(2023, 3, 31);

        var Medicamentos = await _context.Medicamentos
        .Where(e=>e.Inventario.MovimientosInventario
        .Any(t  =>  t.IdTipoMovimientoFk==2 &&
                    t.FechaMovimiento >= primerTrimestreInicio &&
                    t.FechaMovimiento <= primerTrimestreFin))
        .CountAsync();

        return Medicamentos;
    }

    public async Task<IEnumerable<Medicamento>> MedicamentosPrecioMas50Stockmenos100()
    {
        var Medicamentos = await _context.Medicamentos
        .Where(e=>e.Precio >= 50 && e.Inventario.Stock <=100)
        .ToListAsync();

        return Medicamentos;
    }

     public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Medicamentos  as IQueryable<Medicamento>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                    /* .Include(u =>u.Proveedor) */
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return (totalRegistros, registros);
        }

}
