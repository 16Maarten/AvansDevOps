﻿using AvansDevOps.App.Domain.States;

namespace AvansDevOps.App.Domain;

public class Activity
{
    private string _title { get; set; }
    private string _description { get; set; }
    private Person _developer { get; set; }
    private Person _tester { get; set; }
    private int _storyPoints { get; set; }
    private IBacklogItemState _state { get; set; }

    public void ToTodo()
    {
        this._state = _state.StateToDo();
    }
    public void ToDoing()
    {
        this._state = _state.StateDoing();
    }

    public void ToReadyForTesting()
    {
        this._state = _state.StateReadyForTesting();
    }

    public void ToTesting()
    {
        this._state = _state.StateTesting();
    }

    public void ToTested()
    {
        this._state = _state.StateTested();
    }
    public void ToDone()
    {
        // TODO Check of alle activiteiten op done staan
        this._state = _state.StateDone();
    }
}