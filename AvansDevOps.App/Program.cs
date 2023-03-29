// See https://aka.ms/new-console-template for more information
using AvansDevOps.App.Domain;
using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Domain.WorkItemStates;
using AvansDevOps.App.Infrastructure.Services;
using AvansDevOps.App.Infrastructure.Visitors;
using Thread = AvansDevOps.App.Domain.Thread;

//---START FORUM---
Console.WriteLine("------------START FORUM------------");

var forum = new Forum("Design", "This is the design forum");
var user1 = new Developer("Mo");
var user2 = new Developer("Maarten");

var thread = new Thread(
    "Can't align object",
    "I can't align object to the right because...",
    user1
);
forum.AddThread(thread);

var reply1 = new Reply("Ok and?", user2);
thread.AddReply(reply1);

var reply2 = new Reply("What you mean and?", user1);
reply1.AddReply(reply2);

var reply3 = new Reply("What YOU mean what you mean and?", user2);
reply2.AddReply(reply3);

Console.WriteLine(forum.ToString());

Console.WriteLine("User 1 THREADS:");
Console.WriteLine(user1.ThreadsToString());
Console.WriteLine("User 1 REPLIES:");
Console.WriteLine(user1.RepliesToString());
Console.WriteLine("User2 REPLIES:");
Console.WriteLine(user2.RepliesToString());

Console.WriteLine("------------END FORUM------------");

//---END FORUM---

var project = new Project("Bioscoop", new ProductOwner("Ger", "Bioscoop"));
List<Developer> developers = new List<Developer>();
developers.Add(user1);
developers.Add(user2);
var sprint = new ReleaseSprint(
    "Sprint 1",
    DateTime.Now,
    DateTime.Now.AddDays(7),
    Status.Open,
    new ScrumMaster("Marcel"),
    developers
);

var backlogItem1 = new BacklogItem(
    "Bouw FE",
    "Gebruik javascript",
    user1,
    user2,
    5,
    new ToDoState()
);
var backlogItem2 = new BacklogItem("Bouw BE", "Gebruik C#", user2, user1, 5, new ToDoState());
var activity1 = new Activity(
    "Inlog pagina",
    "Maak een inlog pagina",
    user1,
    user2,
    2,
    new ToDoState()
);
var activity2 = new Activity(
    "home pagina",
    "Maak een home pagina",
    user1,
    user2,
    3,
    new ToDoState()
);

project.AddComponent(sprint);
sprint.AddComponent(backlogItem1);
sprint.AddComponent(backlogItem2);
backlogItem1.AddComponent(activity1);
backlogItem1.AddComponent(activity2);

PrintVisitor printVisitor = new PrintVisitor();
project.AcceptVisitor(printVisitor);
