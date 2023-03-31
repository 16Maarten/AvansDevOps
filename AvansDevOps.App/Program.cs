// See https://aka.ms/new-console-template for more information
using AvansDevOps.App.Domain;
using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Domain.WorkItemStates;
using AvansDevOps.App.Infrastructure.Builders;
using AvansDevOps.App.Infrastructure.Services;
using AvansDevOps.App.Infrastructure.Visitors;
using Thread = AvansDevOps.App.Domain.Thread;

//---START FORUM---
Console.WriteLine("------------------------------------START FORUM------------------------------------");

var forum = new Forum("Design", "This is the design forum");
var user1 = new Developer("Mo", "user1@live.com", "user1-slack");
var user2 = new Developer("Maarten", "user2@live.com", "user2-slack");

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

Console.WriteLine("------------------------------------END FORUM------------------------------------\n");

//---END FORUM---


//---START NOTIFICATION---
Console.WriteLine("------------------------------------START NOTIFICATION-----------------------------------");

var publisherService = new PublisherService();
publisherService.AddObserver(new NotificationService());
publisherService.NotifyObservers("MESSAGE!!!!!!!!!!!", user1);
publisherService.NotifyObservers("MESSAGE!!!!!!!!!!!", user2);

Console.WriteLine("------------------------------------END NOTIFICATION------------------------------------\n");
//---END NOTIFICATION---


//---START PROJECT---
Console.WriteLine("------------------------------------START PROJECT------------------------------------");
var project = new Project("Bioscoop", new ProductOwner("Ger", "Bioscoop"));

List<Developer> developers = new List<Developer>();
developers.Add(user1);
developers.Add(user2);
var sprints = new List<Sprint>();
var sprint = new ReleaseSprint(
    1,
    "Sprint 1",
    DateTime.Now,
    DateTime.Now.AddDays(7),
    new ScrumMaster("Marcel"),
    developers
);
sprints.Add(sprint);
var backlogItems = new List<BacklogItem>();

var backlogItem1 = new BacklogItem(1, "Bouw FE", "Gebruik javascript", user1, 5);
var backlogItem2 = new BacklogItem(2, "Bouw BE", "Gebruik C#", user2, 5);
backlogItems.Add(backlogItem1);
backlogItems.Add(backlogItem2);
var activities = new List<Activity>();

var activity1 = new Activity(1, "Inlog pagina", "Maak een inlog pagina", user1, 2);
var activity2 = new Activity(2, "home pagina", "Maak een home pagina", user1, 3);
activities.Add(activity1);
activities.Add(activity2);

var projectBuilder = new ProjectBuilder();

projectBuilder.BuildProject(project);
projectBuilder.SetSprints(sprints);
projectBuilder.SetBacklogItems(1, backlogItems);
projectBuilder.SetActivitys(1, 1, activities);

Project buildProject = projectBuilder.GetResult();
PrintVisitor printVisitor = new PrintVisitor();
buildProject.AcceptVisitor(printVisitor);
project.AcceptVisitor(printVisitor);

Console.WriteLine("------------------------------------END PROJECT------------------------------------\n");
//---END PROJECT---
