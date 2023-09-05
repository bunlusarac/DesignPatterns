namespace DesignPatterns.Behavioral.Command;

public class CommandManager
{
    private Stack<ICommand> _commands = new();

    public void Invoke(ICommand command)
    {
        if (command.CanExecute())
        {
            _commands.Push(command);
            command.Execute();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Undo()
    {
        var command = _commands.Pop();
        command.Undo();
    }

    public void UndoAll()
    {
        while (_commands.Count != 0)
        {
            Undo();
        }
    }
}