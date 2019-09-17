namespace Nemerle.Compiler
{
    public interface IEngine
    {
        /// Send request on Build the Types Tree. It not lead to immediately rebuild project. 
        /// The project will be rebuilded when IDE turn into idle state (user will not be type in editor).
        void RequestOnBuildTypesTree();
    }
}
