namespace DesignPatterns.Behavioral.Command;

public interface ICommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}