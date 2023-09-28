using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CsvHelper;
using Dominio.Entities;
using Microsoft.Extensions.Logging;
using Persistencia.Data;

namespace Persistencie;

    public class ApiFarmaciaContextSeed
    {
        public static async Task SeedAsync(ApiFarmaciaContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.Marcas.Any())
                {
                    using(var readerMarcas = new StreamReader(ruta + @"/Data/Csvs/Marcas.csv"))
                    {
                        using(var csvMarcas = new CsvReader(readerMarcas, CultureInfo.InvariantCulture))
                        {
                            var marcas = csvMarcas.GetRecords<Marca>();
                            context.Marcas.AddRange(marcas);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Presentaciones.Any())
                {
                    using(var readerPresentaciones = new StreamReader(ruta + @"/Data/Csvs/Presentaciones.csv"))
                    {
                        using(var csvPresentaciones = new CsvReader(readerPresentaciones, CultureInfo.InvariantCulture))
                        {
                            var presentaciones = csvPresentaciones.GetRecords<Presentacion>();
                            context.Presentaciones.AddRange(presentaciones);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Paises.Any())
                {
                    using(var readerPaises = new StreamReader(ruta + @"/Data/Csvs/Paises.csv"))
                    {
                        using(var csvPaises = new CsvReader(readerPaises, CultureInfo.InvariantCulture))
                        {
                            var paises = csvPaises.GetRecords<Pais>();
                            context.Paises.AddRange(paises);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Departamentos.Any())
                {
                    using(var readerDepartamentos = new StreamReader(ruta + @"/Data/Csvs/Departamentos.csv"))
                    {
                        using(var csvDepartamentos = new CsvReader(readerDepartamentos, CultureInfo.InvariantCulture))
                        {
                            var ListaDepartamentos = csvDepartamentos.GetRecords<Departamento>();
                            List<Departamento> departamentos = new List<Departamento>();
                            foreach (var item in ListaDepartamentos)
                            {
                                departamentos.Add(new Departamento
                                {
                                    Id = item.Id,
                                    Nombre = item.Nombre,
                                    IdPaisFk = item.IdPaisFk
                                });
                            }
                            context.Departamentos.AddRange(departamentos);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Ciudades.Any())
                {
                    using(var readerCiudades = new StreamReader(ruta + @"/Data/Csvs/Ciudades.csv"))
                    {
                        using(var csvCiudades = new CsvReader(readerCiudades, CultureInfo.InvariantCulture))
                        {
                            var ListaCiudades = csvCiudades.GetRecords<Ciudad>();
                            List<Ciudad> ciudades = new List<Ciudad>();
                            foreach (var item in ListaCiudades)
                            {
                                ciudades.Add(new Ciudad
                                {
                                    Id = item.Id,
                                    Nombre = item.Nombre,
                                    IdDepartamentoFk = item.IdDepartamentoFk
                                });
                            }
                            context.Ciudades.AddRange(ciudades);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Direcciones.Any())
                {
                    using(var readerDirecciones = new StreamReader(ruta + @"/Data/Csvs/Direcciones.csv"))
                    {
                        using(var csvDirecciones = new CsvReader(readerDirecciones, CultureInfo.InvariantCulture))
                        {
                            var ListaDirecciones = csvDirecciones.GetRecords<Direccion>();
                            List<Direccion> direcciones = new List<Direccion>();
                            foreach (var item in ListaDirecciones)
                            {
                                direcciones.Add(new Direccion
                                {
                                    Id = item.Id,
                                    TipoViaPrincipal = item.TipoViaPrincipal,
                                    NumeroViaPrincipal = item.NumeroViaPrincipal,
                                    NumeroViaSecundaria = item.NumeroViaSecundaria,
                                    Barrio = item.Barrio,
                                    Complemento = item.Complemento,
                                    IdCiudadFk = item.IdCiudadFk
                                });
                            }
                            context.Direcciones.AddRange(direcciones);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Pacientes.Any())
                {
                    using(var readerPacientes = new StreamReader(ruta + @"/Data/Csvs/Pacientes.csv"))
                    {
                        using(var csvPacientes = new CsvReader(readerPacientes, CultureInfo.InvariantCulture))
                        {
                            var ListaPacientes = csvPacientes.GetRecords<Paciente>();
                            List<Paciente> pacientes = new List<Paciente>();
                            foreach (var item in ListaPacientes)
                            {
                                pacientes.Add(new Paciente
                                {
                                    Id = item.Id,
                                    Nombre = item.Nombre,
                                    IdDireccionFk = item.IdDireccionFk,
                                    Telefono = item.Telefono
                                });
                            }
                            context.Pacientes.AddRange(pacientes);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Recetas.Any())
                {
                    using(var readerRecetas = new StreamReader(ruta + @"/Data/Csvs/RecetasMedicas.csv"))
                    {
                        using(var csvRecetas = new CsvReader(readerRecetas, CultureInfo.InvariantCulture))
                        {
                            var ListaRecetas = csvRecetas.GetRecords<RecetaMedica>();
                            List<RecetaMedica> recetas = new List<RecetaMedica>();
                            foreach (var item in ListaRecetas)
                            {
                                recetas.Add(new RecetaMedica
                                {
                                    Id = item.Id,
                                    MedicoRemitente = item.MedicoRemitente,
                                    Descripcion = item.Descripcion,
                                    IdPacienteFk = item.IdPacienteFk
                                });
                            }
                            context.Recetas.AddRange(recetas);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Proveedores.Any())
                {
                    using(var readerProveedores = new StreamReader(ruta + @"/Data/Csvs/Proveedores.csv"))
                    {
                        using(var csvProveedores = new CsvReader(readerProveedores, CultureInfo.InvariantCulture))
                        {
                            var ListaProveedores = csvProveedores.GetRecords<Proveedor>();
                            List<Proveedor> proveedores = new List<Proveedor>();
                            foreach (var item in ListaProveedores)
                            {
                                proveedores.Add(new Proveedor
                                {
                                    Id = item.Id,
                                    Nombre = item.Nombre,
                                    Contacto = item.Contacto,
                                    IdDireccionFk = item.IdDireccionFk
                                });
                            }
                            context.Proveedores.AddRange(proveedores);
                            await context.SaveChangesAsync();
                        }
                    }
                }



                if (!context.Inventarios.Any())
                {
                    using(var readerInventarios = new StreamReader(ruta + @"/Data/Csvs/Stock.csv"))
                    {
                        using(var csvInventarios = new CsvReader(readerInventarios, CultureInfo.InvariantCulture))
                        {
                            var Inventarios = csvInventarios.GetRecords<Inventario>();
                            context.Inventarios.AddRange(Inventarios);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.Medicamentos.Any())
                {
                    using(var readerMedicamentos = new StreamReader(ruta + @"/Data/Csvs/Medicamentos.csv"))
                    {
                        using(var csvMedicamentos = new CsvReader(readerMedicamentos, CultureInfo.InvariantCulture))
                        {
                            var ListaMedicamentos = csvMedicamentos.GetRecords<Medicamento>();
                            List<Medicamento> medicamentos = new List<Medicamento>();
                            foreach (var item in ListaMedicamentos)
                            {
                                medicamentos.Add(new Medicamento
                                {
                                    Id = item.Id,
                                    Nombre = item.Nombre,
                                    Precio = item.Precio,
                                    FechaExpiracion = item.FechaExpiracion,
                                    IdProveedorFk = item.IdProveedorFk,
                                    IdPresentacionFk = item.IdPresentacionFk,
                                    IdMarcaFk = item.IdMarcaFk,
                                    IdInventarioFk = item.IdInventarioFk
                                });
                            }
                            context.Medicamentos.AddRange(medicamentos);
                            await context.SaveChangesAsync();
                        }
                    }
                }



                if (!context.Empleados.Any())
                {
                    using(var readerEmpleados = new StreamReader(ruta + @"/Data/Csvs/Empleados.csv"))
                    {
                        using(var csvEmpleados = new CsvReader(readerEmpleados, CultureInfo.InvariantCulture))
                        {
                            var ListaEmpleados = csvEmpleados.GetRecords<Empleado>();
                            List<Empleado> empleados = new List<Empleado>();
                            foreach (var item in ListaEmpleados)
                            {
                                empleados.Add(new Empleado
                                {
                                    Id = item.Id,
                                    Nombre = item.Nombre,
                                    Cargo = item.Cargo,
                                    FechaContratacion = item.FechaContratacion
                                });
                            }
                            context.Empleados.AddRange(empleados);
                            await context.SaveChangesAsync();
                        }
                    }
                }

                if (!context.MovimientosInventarios.Any())
                {
                    using(var readerMovimientosInventario = new StreamReader(ruta + @"/Data/Csvs/MovimientosInventario.csv"))
                    {
                        using(var csvMovimientosInventario = new CsvReader(readerMovimientosInventario, CultureInfo.InvariantCulture))
                        {
                            var ListaMovimientosInventario = csvMovimientosInventario.GetRecords<MovimientoInventario>();
                            List<MovimientoInventario> movimientosInventario = new List<MovimientoInventario>();
                            foreach (var item in ListaMovimientosInventario)
                            {
                                movimientosInventario.Add(new MovimientoInventario
                                {
                                    Id = item.Id,
                                    IdEmpleadoFk = item.IdEmpleadoFk,
                                    IdPacienteFk = item.IdPacienteFk,
                                    Cantidad = item.Cantidad,
                                    Precio = item.Precio,
                                    FechaMovimiento = item.FechaMovimiento,
                                    IdTipoMovimientoFk = item.IdTipoMovimientoFk,
                                    IdFacturaFk = item.IdFacturaFk,
                                    IdInventarioFk = item.IdInventarioFk
                                });
                            }
                            context.MovimientosInventarios.AddRange(movimientosInventario);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<ApiFarmaciaContext>();
                logger.LogError(ex.Message);
            }
        }
    }
