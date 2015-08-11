namespace Fluct.Repo
{
    public interface IDeletable
    {
        bool IsDeleted { get; }
        void MarkAsDeleted();
    }
}
