using KanbanBoard.Enums;
using Microsoft.Practices.Prism.Events;
using System;

namespace KanbanBoard.Events
{
    public class RequestChangeStateEvent : CompositePresentationEvent<Tuple<State, string>>
    {
    }
}
