// See https://aka.ms/new-console-template for more information
using AvansDevOps.App.Domain;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Services;
using Thread = AvansDevOps.App.Domain.Thread;

var publisher = new PublisherService<string>();
var report = new Report("");

var forum = new Forum("Design", "This is the design forum");
var user1 = new Developer("Mo");
var user2 = new Developer("Maarten");
var thread = new Thread("Can't align object", "I can't align object to the right because...", user1);

forum.AddThread(thread);

var reply1 = new Reply("Ok and?", user2);

thread.AddReply(reply1);

var reply2 = new Reply("What you mean and?", user1);

reply1.AddReply(reply2);

var reply3 = new Reply("What YOU mean what you mean and?", user2);

reply2.AddReply(reply3);

Console.WriteLine(forum.ToString());
