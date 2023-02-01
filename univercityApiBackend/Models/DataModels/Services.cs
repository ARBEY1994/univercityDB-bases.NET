namespace univercityApiBackend.Models.DataModels
{
    public class Services
    {

        static public void SearchEmail()
        {
            var Users =new[]
            {
                new User()
                {
                    Name= "Alberto",
                    LastName="Castro",
                    Email="castro@gmail.com",
                    Password="12345"

                }, new User()
                {
                    Name= "Carlos",
                    LastName="Pardo",
                    Email="pardo@gmail.com",
                    Password="12345d"

                }, new User()
                {
                    Name= "Alfredo",
                    LastName="Bastidas",
                    Email="alfre@gmail.com",
                    Password="123445"

                }

                
            }
            var buscarEmail = Users.Select(x => x.Email);
        },
         static public void SearchStudents()
        {
            var Students = new[]
            {
                new Student()
                {
                    Name= "Alberto",
                    LastName="Castro",
                    Dob=15/02/1994,
                    Cursos=new[]
                    {
                        new Curso
                        {
                            Name="Arquitectura",
                            ShortDescription="curso de arquitectura",
                            LongDescription="curso de arquitectura de software, enfocado en principiantes y apasionados",
                            TargetAudiences="juniors",
                            Objectives="ampliar conocimientos",
                            Requirements="tecnico o tecnologo en desarrollo",
                            Level=Level.Basic,
                           

                        }
                    }

                }, 


            }
            var buscarStudent = Students.Select(x => x.Dob > 01/01/2005);

            bool AlumnosConCursos = Students.Any(student => student.Cursos.Any());
        },
         static public void Cursos()
        {
            var cursos = new[]
            {
                new Curso()
                {
                            Name="Desarrollo",
                            ShortDescription="curso de desarrollo web",
                            LongDescription="curso de desarrollo web, enfocado en principiantes y apasionados",
                            TargetAudiences="senior",
                            Objectives="ampliar conocimientos",
                            Requirements="tecnico o tecnologo en desarrollo",
                            Level=Level.Advanced,
                            Categories= new[]
                            {
                                new Category()
                                {
                                    Name=" web"
                                }
                            },
                            Chapter= new[]
                            {
                                new Chapter()
                                {

                                }
                            },
                            Students =new[]
                            {
                                new Student()
                                {
                    Name= "Facundo",
                    LastName="Guerra",
                    Dob=15/02/1997,
                                }
                            }


                },


            }
            bool buscarAlumnoNivelDeterminado = cursos.Any(x => x.Level);
            bool buscarAlumnoNivelDeterminadoYcategoriaDeterminada = cursos.Any(x => x.Level);
            bool buscarAlumnoNivelDeterminadoYcategoriaDeterminada = cursos.Any(x => x.Categories.Any(x => x.Categoty));
            bool buscarAlumSincurso= cursos.Any();




        }
    }
}
