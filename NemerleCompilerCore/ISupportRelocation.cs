namespace Nemerle.Compiler
{
    public interface ISupportRelocation
    {
        void RelocateImpl(RelocationInfo info);
    }
}