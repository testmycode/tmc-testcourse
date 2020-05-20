using System;
using System.IO;
using NUnit.Framework;
using Exercise;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ExerciseTest
{
  public class Tests
  {
    string target = "../../../";
    string current = Directory.GetCurrentDirectory();

    [SetUp]
    public void Init()
    {
      Directory.SetCurrentDirectory(target);
    }

    [TearDown]
    public void End()
    {
      Directory.SetCurrentDirectory(current);
    }

    [Test]
    public void PersonExampleShouldWork()
    {
      using (StringWriter sw = new StringWriter())
      {
        TextWriter stdout = Console.Out;
        Console.SetOut(sw);
        Person ada = new Person("Ada Lovelace", "24 Maddox St. London W1S 2QN");
        Person esko = new Person("Esko Ukkonen", "Mannerheimintie 15 00100 Helsinki");
        Console.WriteLine(ada);
        Console.WriteLine(esko);
        Console.SetOut(stdout);
        string example = "Ada Lovelace, 24 Maddox St. London W1S 2QN\nEsko Ukkonen, Mannerheimintie 15 00100 Helsinki\n";
        Assert.AreEqual(example, sw.ToString().Replace("\r\n", "\n"), "The example with Persons should work!");
      }
    }

    [Test]
    public void StudentExampleShouldWork()
    {
      using (StringWriter sw = new StringWriter())
      {
        TextWriter stdout = Console.Out;
        Console.SetOut(sw);
        Student ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
        Console.WriteLine(ollie);
        ollie.Study();
        Console.WriteLine(ollie);
        string example = "Ollie, 6381 Hollywood Blvd. Los Angeles 90028 credits: 0\nOllie, 6381 Hollywood Blvd. Los Angeles 90028 credits: 1\n";
        Assert.AreEqual(example, sw.ToString().Replace("\r\n", "\n"), "The example with one Student should work!");
      }
    }

    [Test]
    public void TeacherExampleShouldWork()
    {
      using (StringWriter sw = new StringWriter())
      {
        TextWriter stdout = Console.Out;
        Console.SetOut(sw);
        Teacher ada = new Teacher("Ada Lovelace", "24 Maddox St. London W1S 2QN", 1200);
        Teacher esko = new Teacher("Esko Ukkonen", "Mannerheimintie 15 00100 Helsinki", 5400);
        Console.WriteLine(ada);
        Console.WriteLine(esko);
        Console.SetOut(stdout);
        string example = "Ada Lovelace, 24 Maddox St. London W1S 2QN salary 1200 per month\nEsko Ukkonen, Mannerheimintie 15 00100 Helsinki salary 5400 per month\n";
        Assert.AreEqual(example, sw.ToString().Replace("\r\n", "\n"), "The example with Teachers should work!");
      }
    }


    [Test]
    public void AddingAllKindsToListShouldWork()
    {
      using (StringWriter sw = new StringWriter())
      {
        List<Person> people = new List<Person>();
        TextWriter stdout = Console.Out;
        Console.SetOut(sw);
        Person heikki = new Person("Heikki Ahonen", "Under the Bridge");
        Student ollie = new Student("Matt LeBlanc", "Hollywood");
        Teacher ada = new Teacher("Ada Lovelace", "24 Maddox St. London W1S 2QN", 1200);
        people.Add(ada);
        people.Add(heikki);
        people.Add(ollie);
        foreach (Person person in people)
        {
          Console.WriteLine(person);
        }
        string example = "Ada Lovelace, 24 Maddox St. London W1S 2QN salary 1200 per month\nHeikki Ahonen, Under the Bridge\nMatt LeBlanc, Hollywood credits: 0\n";
        Assert.AreEqual(example, sw.ToString().Replace("\r\n", "\n"), "All should implement Person!");
      }
    }


  }
}