﻿using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Notifiers;

namespace AvansDevOps.App.Infrastructure.Adapters;

public class OutlookNotifierAdapter : INotifier
{
    private OutlookNotifier _notifier = new OutlookNotifier();
    public void SendNotification(string message, Person user)
    {
        _notifier.EmailSendOut(message, user);
    }
}