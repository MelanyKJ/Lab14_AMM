
using Lab14_AMM_A.DataContext;
using Lab14_AMM_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab14_AMM_A.Services
{
    public class EstudianteService
    {
        private readonly AppDbContext _context;

        public EstudianteService() => _context = App.GetContext();


        public bool Create(Estudiante item)
        {
            try
            {
                //EntityFrameworkCore
                _context.Estudiantes.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool CreateRange(List<Estudiante> items)
        {
            try
            {
                //EntityFrameworkCore
                _context.Estudiantes.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Estudiante> Get()
        {
            return _context.Estudiantes.ToList();
        }


        public List<Estudiante> GetByText(string text)
        {
            return _context.Estudiantes.Where(x => x.Nombre.Contains(text) || x.Apellido.Contains(text)).ToList();
        }

        public Estudiante GetById(int id)
        {
            return _context.Estudiantes.Where(x => x.EstudianteId == id).FirstOrDefault();
        }

        public bool UpdateEstudiante(Estudiante estudiante, int id)
        {
            try
            {
                var model = GetById(id);
                model.Nombre = estudiante.Nombre;
                model.Apellido = estudiante.Apellido;
                model.Direccion = estudiante.Direccion;
                model.Dni = estudiante.Dni;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteEstudiante(int id)
        {
            try
            {
                var model = GetById(id);
                _context.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
