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

    public async Task<IEnumerable<Inventario>> GetStockCincu()
    {   
        var medicamentosMenorCincu = await _context.Inventarios.Where(m => m.Stock < 50).ToListAsync();
        return medicamentosMenorCincu;
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
    public async Task<IEnumerable<KeyValuePair<string, int>>> TotalMedicamentosVendidosXmes2023()
    {
        var totalXmes = await _context.MovimientosInventarios
        .Where(ti=>ti.IdTipoMovimientoFk == 2 && ti.FechaMovimiento.Year == 2023)
        .GroupBy(ti =>ti.FechaMovimiento.ToString("MMMM yyyy"))
        .Select(group=> new KeyValuePair<string,int>(
                group.Key,
                group.Sum(ti=>ti.Cantidad)
        ))        
        .ToListAsync();

        return totalXmes;
    }

    public async Task<IEnumerable<Medicamento>> MedicamentosVendidosXmes()
    {
        var Medicamentos = await _context.Medicamentos
        .Where(e => e.Inventario.MovimientosInventario
            .Where(mi => mi.IdTipoMovimientoFk == 2 && mi.FechaMovimiento.Year == 2023)
            .GroupBy(mi=> mi.FechaMovimiento.Month )
            .All(group=>group.Any())
        ).ToListAsync();

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
}
