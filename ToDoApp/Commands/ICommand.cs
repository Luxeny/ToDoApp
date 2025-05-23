namespace ToDoApp.Commands
{
    public interface ITaskCommand
    {
        void Execute();
        void Undo();
    }
}