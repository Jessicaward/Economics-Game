using Economics_Game.Contract;

namespace Economics_Game.Actions
{
    public class SaveAndQuitAction :IAction
    {
        public void ExecuteAction()
        {
            //todo: save game from here.
            //something like:
            //FileManager.SaveGame();
            Program.Exit = true;
        }
    }
}