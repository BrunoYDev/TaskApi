using System.ComponentModel;

namespace TaskApi.Enums
{
    public enum TaskStatus
    {
        [Description("A fazer")]
        ToDo = 1,
        [Description("Em Andamento")]
        OnGoing = 2,
        [Description("Concluido")]
        Done = 3
    }
}