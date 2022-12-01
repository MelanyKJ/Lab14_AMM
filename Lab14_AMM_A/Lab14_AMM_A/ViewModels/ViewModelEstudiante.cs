using Lab14_AMM_A.Models;
using Lab14_AMM_A.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab14_AMM_A.ViewModels
{
    public class ViewModelEstudiante : BaseViewModel
    {
        private string color;
        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }


        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }


        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { SetValue(ref this.apellido, value); }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { SetValue(ref this.direccion, value); }
        }

        private string dni;
        public string Dni
        {
            get { return dni; }
            set { SetValue(ref this.dni, value); }
        }

        private int idEstudiante;
        public int IdEstudiante
        {
            get { return idEstudiante; }
            set { SetValue(ref this.idEstudiante, value); }
        }

        private List<Estudiante> estudiantes;
        public List<Estudiante> Estudiantes
        {
            get { return this.estudiantes; }
            set { SetValue(ref this.estudiantes, value); }
        }

        private Estudiante estudiante;
        public Estudiante Estudiante
        {
            get { return this.estudiante; }
            set { SetValue(ref this.estudiante, value); }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectOneCommand { get; set; }
        public ViewModelEstudiante()
        {
            EstudianteService service = new EstudianteService();
            Estudiantes = service.Get();

            SearchCommand = new Command(() =>
            {
                EstudianteService service = new EstudianteService();
                Estudiantes = service.Get();
            });

            InsertCommand = new Command(() =>
            {
                EstudianteService service = new EstudianteService();
                if (IdEstudiante != 0)
                {
                    Console.WriteLine(IdEstudiante);
                    service.UpdateEstudiante(new Estudiante { Nombre = Nombre, Apellido = Apellido, Direccion = Direccion, Dni = Dni, EstudianteId = IdEstudiante }, IdEstudiante);

                    Nombre = "";
                    Apellido = "";
                    Direccion = "";
                    Dni = "";
                    IdEstudiante = 0;
                }
                else
                {
                    int newEstudianteId = service.Get().Count + 1;
                    service.Create(new Estudiante { Nombre = Nombre, Apellido = Apellido, Direccion = Direccion, Dni = Dni, EstudianteId = IdEstudiante });
                    Nombre = "";
                    Apellido = "";
                    Direccion = "";
                    Dni = "";
                }
                Estudiantes = service.Get();
            });

            SelectOneCommand = new Command<int>(execute: (int parameter) =>
            {
                EstudianteService service = new EstudianteService();
                int ide = parameter;
                Estudiante = service.GetById(ide);
                Nombre = Estudiante.Nombre;
                Apellido = Estudiante.Apellido;
                Direccion = Estudiante.Direccion;
                Dni = Estudiante.Dni;
                IdEstudiante = Estudiante.EstudianteId;
                //Console.WriteLine(IdPerson);
            });

            DeleteCommand = new Command<int>(execute: (int parameter) =>
            {
                EstudianteService service = new EstudianteService();
                int ide = parameter;
                service.DeleteEstudiante(ide);
                Estudiantes = service.Get();
            });
        }


    }
}
