using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"

            };
            // 1. SELECT * of cars
            var CarList = from car in cars select car;

            foreach (var car in CarList)
            {
                Console.WriteLine(car);
            }

            //SELECT WHERE car is Audi

            var AudiList = from car in cars where car.Contains("Audi") select car;
            foreach (var Audi in AudiList)
            {
                Console.WriteLine(Audi);
            }
        }

        //Numbers example

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // multiplicar todos los numeros x 3
            //todos los numeros menos el 9
            //orden ascendente

            var processedNumberList = numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }
        static public void SearchExample()
        {
            List<string> textList = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                 "e",
                 "f",
                "gr",
                "j"
            };
            // 1. econtrar el primer elemento
            var first = textList.First();
            //2. encontrar el primer elemento que sea "c"
            var cText = textList.First(text => text.Equals("c"));
            //3. encontrar primer elemento que contenga "j"
            var jText = textList.First(text => text.Contains("j"));
            // 4. buscar primer elemento con "z" y si no esta mostrar uno por defaul
            var firstOrDefaulText = textList.FirstOrDefault(text => text.Contains("z"));//una lsita vacia o una que contenga primer elemento con"z"

            // 5. buscar ultimo elemento con "z" y si no esta mostrar uno por defaul
            var LastOrDefaulText = textList.LastOrDefault(text => text.Contains("z"));//una lsita vacia o una que contenga ultimo elemento con "z"

            //6. valor unico
            var uniqueText = textList.Single();
            var uniqueOrDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //obtener {4,8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);//{4,8}
        }
        static public void MultipleSelect()
        {
            //seleccionar muchas
            string[] myOpinions =
            {
                "opinion 1, text 1",
                "opinion 1, text 1",
                "opinion 1, text 1"
            };
            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
                {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Heiner",
                            Email = "heiner@gmail.com",
                            Salary = 3000

                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pedro",
                            Email = "pedro@gmail.com",
                            Salary = 5000

                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "pancracio",
                            Email = "pancracior@gmail.com",
                            Salary = 6000

                        }
                    }

                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Maria",
                            Email = "maria@gmail.com",
                            Salary = 3000

                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Magumbo",
                            Email = "magu@gmail.com",
                            Salary = 2000

                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "petronilo",
                            Email = "petro@gmail.com",
                            Salary = 1000

                        }

                    }
                }
            };
            //obtener los empleados dee todas las empresas
            var employesList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //saber si hay una lista vacia
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // que todas tengan empleados de mas de 1000 de salario
            bool hasEmployesWithSalaryMoreThan1000 =
                enterprises.Any(enterprise => enterprise.Employees.Any(employe => employe.Salary >= 1000));
        }
        static public void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //inner join, elementos que esten en ambas listas, en comun
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };
            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement });

            //auto unir a la izquierda
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(e => e == element).DefaultIfEmpty()
                                 select new {Element = element ,SecondElement= secondElement}; 

            //auto unir a la derecha
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };


            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }
        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            //SKIP

            var skipTwoFirstValues = myList.Skip(2);// {3,4,5,6,7,8,9,10}

            var skipTwoLastValues = myList.SkipLast(2);// {1,2,3,4,5,6,7,8}

             var skipWhile = myList.SkipWhile(e => e < 4);//{4,5,6,7,8}

            //TAKE

            var takeTwoFirstValues = myList.Take(2);//{1,2}
            var takeTwoLastValues = myList.TakeLast(2); //{9,10}
            var TakeWhile = myList.TakeWhile(e => e < 4);//{1,2,3}


        }
    }
}