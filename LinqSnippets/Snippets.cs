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

        //paging con Skip y take
       static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultPerPage)
        {
            int starIndex = (pageNumber - 1) * resultPerPage;
            return collection.Skip(starIndex).Take(resultPerPage);
        }
        // variables
        public static void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;
            Console.WriteLine("Average:{0}", numbers.Average());
            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Square:{1}", number, Math.Pow(number, 2));
            }

        }
        //ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "trhee", "four", "five" };
            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);
            // {"1=one","2=two",...}


        }
        //REPEAT AND  RANGE
        static public void RepeatRangeLinq()
        {
            // generate collection  from 1-1000
            var first1000 = Enumerable.Range(0, 1000);
            // Repeat a value N times 
            IEnumerable<string> fivex = Enumerable.Repeat("x", 5); // {"x","x","x","x","x"}
        }

        static public void StudentLinq()
        {
            var classRoom = new[]
            {
                new Student
                {   Id= 1,
                    Name= "heiner",
                    Grade= 9,
                    Certified = true,

                },
                new Student
                {   Id= 2,
                    Name= "pedro",
                    Grade= 10,
                    Certified = false,

                },
                new Student
                {   Id= 3,
                    Name= "juan",
                    Grade= 6,
                    Certified = true,

                },
                new Student
                {   Id= 4,
                    Name= "martin",
                    Grade= 9,
                    Certified = true,

                }
            };
            var certifiedStudent = from student in classRoom
                                   where student.Certified
                                   select student;
            var notCertified = from student in classRoom
                               where student.Certified == false
                               select student;
            var aprovedStudent = from student in classRoom
                                 where student.Grade > 5 && student.Certified == true
                                 select student;



        }

        //ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2);// false

            var emptyList = new List<int>();
            bool allNumberAreGreaterThan0 = numbers.All(x => x >= 0); //true
        }

        //AGGREGATE
        static public void AgreggateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // sumar todos los numeos
            int sum = numbers.Aggregate((PreviSum, current) => PreviSum + current);
            // 0,1 =>1
            //1,2=>3
            //3,4=>7
            //etc

            string[] words = { "hello,", "my", "name", "is", "heiner" };
            string greeting = words.Aggregate((prevGreting, current) => prevGreting + current);

            //""+"hello," => hello,
            // "hello"+"my" => hello my
            // etc


        }
        //DISCTINC
        static public void DistinValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5,6, 6, 5, 4, 3, 2, 1 };
            IEnumerable<int> distingValues = numbers.Distinct();
        }

        //GROUPBY
         static public void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // obtain only even numbers  and generate  two groups
            var grouped = numbers.GroupBy(x => x % 2==0);
            //we  will  have two groups:
            // 1. the group that doesnt  fit the condition (odd numbers)
            //2. the group  that fits the consitions (event numbers)
            foreach(var group in grouped)
            {
                foreach(var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ...2,4,6,8(firs de odd  and then the even
                }
            }

            //Another example
            var classRoom = new[]
           {
                new Student
                {   Id= 1,
                    Name= "heiner",
                    Grade= 9,
                    Certified = true,

                },
                new Student
                {   Id= 2,
                    Name= "pedro",
                    Grade= 10,
                    Certified = false,

                },
                new Student
                {   Id= 3,
                    Name= "juan",
                    Grade= 6,
                    Certified = true,

                },
                new Student
                {   Id= 4,
                    Name= "martin",
                    Grade= 9,
                    Certified = true,

                }
            };
            var certifiedQuery = classRoom.GroupBy(student => student.Certified);
            // we obtain two groups
            // students not certified
            // students certified
            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("-----{0}---", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name); // 1,3,5,7,9 ...2,4,6,8(firs de odd  and then the even
                }
            }

        }

        static public void RelationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id= 1,
                    Title = "mi primer post",
                    Content = "mi primer content",
                    Created = DateTime.Now,
                    Comments= new List<Comment>()
                    {
                        new Comment()
                        {
                            Id= 1,
                            Created= DateTime.Now,
                            Title= "mi primer comment",
                            Content="mi primer content"

                        },
                        new Comment()
                        {
                            Id= 2,
                            Created= DateTime.Now,
                            Title= "mi second comment",
                            Content="mi second content"

                        },
                    }
                },
                 new Post()
                {
                    Id= 2,
                    Title = "mi second post",
                    Content = "mi second content",
                    Created = DateTime.Now,
                    Comments= new List<Comment>()
                    {
                        new Comment()
                        {
                            Id= 3,
                            Created= DateTime.Now,
                            Title= "mi new comment",
                            Content="mi new content"

                        },
                        new Comment()
                        {
                            Id= 4,
                            Created= DateTime.Now,
                            Title= "mi new comment",
                            Content="mi new content"

                        },
                    }
                }
            };

            var commentWithContent = posts.SelectMany(
                post => post.Comments,
                (post, comment) => new { PostId = post.Id, CommentCopntent = comment.Content });
        }
    }  
 

}